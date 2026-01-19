namespace Generic_Ecommerce.Application.Exceptions
{
    public static class AppErrorCatalog
    {
        public static readonly Error CreateCustomerCustomerExists = new("CREATECUSTOMER_CUSTOMEREXISTS", "Ese cliente ya existe en el sistema.");
        public static readonly Error GetCustomerCustomerNotFound = new("GETCUSTOMER_CUSTOMERNOTFOUND", "Ese cliente no existe en el sistema.");

        public static readonly Error OrderNotFound = new("ORDER_NOTFOUND", "La orden no existe en el sistema.");
        public static readonly Error OrderOrderItemsEmpty = new("ORDER_ORDERITEMS_EMPTY", "La orden debe contar con al menos un producto y no puede estar vacía.");
        public static readonly Error GetCustomerOrderEmpty = new("ORDER_GETCUSTOMERORDER_EMPTY", "El usuario no tiene ordenes de compras asociadas.");

        public static readonly Error ProductNotFound = new("PRODUCT_NOTFOUND", "Ese producto no existe en el sistema.");
        public static readonly Error ProductOutOfStock = new("PRODUCT_OUTOFSTOCK", "Ese producto se encuentra con faltante de stock.");
        public static readonly Error CreateProductNameEmpty = new("PRODUCT_CREATEPRODUCT_NAMEEMPTY", "El nombre del producto no puede estar vacío.");
        public static readonly Error CreateProductPriceNegative = new("PRODUCT_CREATEPRODUCT_PRICENEGATIVE", "El precio del producto no puede ser negativo.");
        public static readonly Error CreateProductStockQuantityNegative = new("PRODUCT_CREATEPRODUCT_STOCKQNEGATIVE", "El stock del producto no puede ser negativo.");
    }

}
