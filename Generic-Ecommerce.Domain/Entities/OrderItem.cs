using Generic_Ecommerce.Domain.Exceptions;

namespace Generic_Ecommerce.Domain.Entities
{
    public class OrderItem
    {
        ///// <summary>
        ///// ID de la relación producto <-> orden de compra
        ///// </summary>
        //public Guid Id { get; private set; }

        ///// <summary>
        ///// ID de la orden a la que esta asociada este producto. Campo requerido.
        ///// </summary>
        //public Guid OrderId { get; private set; }

        /// <summary>
        /// ID del producto que esta relacionado con la orden de compra. Campo requerido.
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Cantidad del producto asociado a la orden de compra. Campo requerido.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Precio unitario del producto asociado a la orden de compra. Campo requerido.
        /// </summary>
        public decimal UnitPrice { get; private set; }

        public OrderItem(Guid productId, int quantity, decimal unitPrice)
        {
            if (productId == Guid.Empty)
                throw new DomainException(ErrorCatalog.ProductIdEmpty.Code, ErrorCatalog.ProductIdEmpty.Message);

            if (quantity < 0)
                throw new DomainException(ErrorCatalog.ProductQuantityNegative.Code, ErrorCatalog.ProductQuantityNegative.Message);

            if (unitPrice < 0m)
                throw new DomainException(ErrorCatalog.ProductPriceNegative.Code, ErrorCatalog.ProductPriceNegative.Message);

            //Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        /// <summary>
        /// Obtiene el total de este item de la orden de compra multiplicando la cantidad por el precio unitario.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal() => Quantity * UnitPrice;
    }
}
