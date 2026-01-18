using Generic_Ecommerce.Application.Exceptions;
using Generic_Ecommerce.Application.Interfaces.Repositories;
using MediatR;

namespace Generic_Ecommerce.Application.Features.Customer.CreateCustomer
{
    public class CreateCustomerHandler
        : IRequestHandler<CreateCustomerCommand, Result<Guid>>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var exists = await _customerRepository.ExistsByEmailAsync(request.Email);
            if (exists)
                throw new BusinessException(AppErrorCatalog.CreateCustomerCustomerExists.Code, AppErrorCatalog.CreateCustomerCustomerExists.Message);

            var customer = new Domain.Entities.Customer(
                request.Id,
                request.Name,
                request.Email,
                request.PhoneNumber
            );

            await _customerRepository.AddAsync(customer);
            return Result<Guid>.Ok(customer.Id);
        }
    }
}
