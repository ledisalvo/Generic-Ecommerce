using Generic_Ecommerce.Domain.Enums;
using Generic_Ecommerce.Domain.Exceptions;

namespace Generic_Ecommerce.Domain.Entities
{
    public class Order
    {
        /// <summary>
        /// ID de la orden de compra
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// ID del cliente. Campo requerido
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Precio total de la orden. Campo requerido
        /// </summary>
        public decimal TotalAmount { get; private set; }

        /// <summary>
        /// Fecha de creación de la orden. Campo requerido
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Estado de la orden: Pending, Paid, Shipped, Delivered, Cancelled
        /// </summary>
        public OrderStatus Status { get; private set; }

        /// <summary>
        /// Productos que componen la orden de compra.
        /// </summary>
        public List<OrderItem> _orderItem = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItem.AsReadOnly();

        public Order(Guid id, Guid customerId, decimal totalAmount, DateTime createdAt, OrderStatus status, List<OrderItem> orderItems)
        {
            if (customerId == Guid.Empty)
                throw new DomainException(ErrorCatalog.CustomerIdEmpty.Code, ErrorCatalog.CustomerIdEmpty.Message);

            if (totalAmount < 0m)
                throw new DomainException(ErrorCatalog.OrderTotalAmountNegative.Code, ErrorCatalog.OrderTotalAmountNegative.Message);

            if (orderItems.Count == 0)
                throw new DomainException(ErrorCatalog.OrderOrderItemsEmpty.Code, ErrorCatalog.OrderOrderItemsEmpty.Message);


            Id = Guid.NewGuid();
            CustomerId = customerId;
            TotalAmount = totalAmount;
            CreatedAt = createdAt == default ? DateTime.UtcNow : createdAt;
            Status = status;
        }

        /// <summary>
        /// Agrega un producto a una orden de compra
        /// </summary>
        /// <param name="orderItem">Objeto que representa el item (producto) de la orden</param>
        /// <exception cref="DomainException"></exception>
        public void AddItem(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new DomainException(ErrorCatalog.OrderOrderItemsEmpty.Code, ErrorCatalog.OrderOrderItemsEmpty.Message);

            if (Status != OrderStatus.Pending)
                throw new DomainException(ErrorCatalog.OrderStatusPending.Code, ErrorCatalog.OrderStatusPending.Message);

            _orderItem.Add(orderItem);
        }

        /// <summary>
        /// Obtiene el monto total de la orden de compra que tiene que pagar el cliente.
        /// </summary>
        public void CalculateTotal()
        {
            TotalAmount = _orderItem.Sum(i => i.GetTotal());
        }

        /// <summary>
        /// Cambia el estado de la orden de compra.
        /// </summary>
        /// <param name="newStatus"></param>
        /// <exception cref="DomainException"></exception>
        public void ChangeStatus(OrderStatus newStatus)
        {
            if (!IsValidTransition(Status, newStatus))
                throw new DomainException(ErrorCatalog.OrderStatusInvalidTransition.Code, ErrorCatalog.OrderStatusInvalidTransition.Message);

            Status = newStatus;
        }

        private static bool IsValidTransition(OrderStatus current, OrderStatus next)
        {
            return (current, next) switch
            {
                (OrderStatus.Pending, OrderStatus.Paid) => true,
                (OrderStatus.Paid, OrderStatus.Shipped) => true,
                (OrderStatus.Shipped, OrderStatus.Delivered) => true,
                (_, OrderStatus.Cancelled) => true,
                _ => false
            };
        }
    }
}