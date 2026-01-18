using Generic_Ecommerce.Application.Features.Orders.GetCustomerOrders;

namespace Generic_Ecommerce.Application.Features.Customer.GetCustomerById
{
    public class CustomerDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public List<CustomerOrderDto> Orders { get; set; } = new();
    }

}
