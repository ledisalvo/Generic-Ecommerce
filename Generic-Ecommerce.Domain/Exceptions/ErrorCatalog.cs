namespace Generic_Ecommerce.Domain.Exceptions
{
    /// <summary>
    /// Catálogo de errores típicos para utilizar y que los mensajes de errores queden homologados.
    /// </summary>
    public static class ErrorCatalog
    {
        #region CUSTOMER
        public static readonly Error CustomerIdEmpty = new("CUSTOMER_ID_EMPTY", "El ID del cliente está vacío y es requerido.");
        public static readonly Error CustomerNameEmpty = new("CUSTOMER_NAME_EMPTY", "El nombre del cliente está vacío y es requerido.");
        public static readonly Error CustomerEmailEmpty = new("CUSTOMER_EMAIL_EMPTY", "El email del cliente está vacio y es un campo requerido");
        public static readonly Error CustomerOrderEmpty = new("CUSTOMER_ORDER_EMPTY", "No se puede asociar una orden de compra vacía a un cliente.");
        #endregion CUSTOMER

        #region ORDER
        public static readonly Error OrderIdEmpty = new("ORDER_ID_EMPTY", "El ID de la orden está vacio y es un campo requerido.");
        public static readonly Error OrderTotalAmountNegative = new("ORDER_TOTALAMOUNT_NEGATIVE", "El monto total de la orden no puede ser negativo.");
        public static readonly Error OrderStatusPending = new("ORDER_STATUS_PENDING", "La orden no se puede modificar mientras se encuentre en estado pendiente.");
        public static readonly Error OrderStatusInvalidTransition = new("ORDER_STATUS_INVALIDTRANSITION", "Esa transición es inválida entre esos dos estados");
        #endregion ORDER

        #region PRODUCT
        public static readonly Error ProductIdEmpty = new("PRODUCT_ID_EMPTY", "El ID del producto está vacio y es un campo requerido.");
        public static readonly Error ProductNameEmpty = new("PRODUCT_NAME_EMPTY", "El nombre del producto está vacio y es un campo requerido.");
        public static readonly Error ProductPriceNegative = new("PRODUCT_PRICE_NEGATIVE", "El precio del producto no puede ser negativo.");
        public static readonly Error ProductStockNegative = new("PRODUCT_STOCK_NEGATIVE", "El stock del producto no puede ser negativo.");
        public static readonly Error ProductQuantityNegative = new("PRODUCT_QUANTITY_NEGATIVE", "La cantidad de los productos no puede ser negativa.");
        public static readonly Error ProductStockInsufficient = new("PRODUCT_STOCK_INSUFFICIENT", "No hay Stock suficiente para este producto.");
        #endregion PRODUCT

        #region ORDER ITEM
        public static readonly Error OrderItemEmpty = new("ORDERITEM_STOCK_NEGATIVE", "El stock del producto no puede ser negativo.");
        #endregion ORDER ITEM
    }

    public record Error(string Code, string Message);
}
