using Generic_Ecommerce.Domain.Exceptions;

namespace Generic_Ecommerce.Domain.Entities
{
    public class Customer
    {
        /// <summary>
        /// ID del cliente
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Nombre del cliente. Campo requerido
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Email del cliente. Campo requerido y debe ser único
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Número de teléfono del cliente. Campo opcional
        /// </summary>
        public string? PhoneNumber { get; private set; }

        /// <summary>
        /// Lista de pedidos del cliente.
        /// </summary>
        private readonly List<Order> _orders = new();
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        public Customer(Guid id, string name, string email, string? phoneNumber = null)
        {
            if (id == Guid.Empty)
                throw new DomainException(ErrorCatalog.CustomerIdEmpty.Code, ErrorCatalog.CustomerIdEmpty.Message);

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(ErrorCatalog.CustomerNameEmpty.Code, ErrorCatalog.CustomerNameEmpty.Message);

            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException(ErrorCatalog.CustomerEmailEmpty.Code, ErrorCatalog.CustomerEmailEmpty.Message);

            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Modifica el nombre del cliente.
        /// </summary>
        /// <param name="name">Nombre completo del cliente</param>
        /// <exception cref="DomainException">CUSTOMER_NAME_EMPTY: El nombre del cliente está vacío y es requerido.</exception>
        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(ErrorCatalog.CustomerNameEmpty.Code, ErrorCatalog.CustomerNameEmpty.Message);

            Name = name;
        }

        /// <summary>
        /// Modifica el número de teléfono del cliente.
        /// </summary>
        /// <param name="phoneNumber">Nombre completo del cliente</param>
        public void ChangePhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;

        /// <summary>
        /// Asocia una orden de compra a un cliente
        /// </summary>
        /// <param name="order">Objeto que representa la entidad Order</param>
        /// <exception cref="DomainException">CUSTOMER_ORDER_EMPTY: No se puede asociar una orden de compra vacía a un cliente.</exception>
        public void AddOrder(Order order)
        {
            if (order == null)
                throw new DomainException(ErrorCatalog.CustomerOrderEmpty.Code, ErrorCatalog.CustomerOrderEmpty.Message);

            _orders.Add(order);
        }
    }
}