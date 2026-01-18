using Generic_Ecommerce.Domain.Exceptions;

namespace Generic_Ecommerce.Domain.Entities
{
    public class Product
    {
        /// <summary>
        /// ID del producto
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Nombre del producto. Campo requerido
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Precio del producto. Campo requerido
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Cantidad de stock disponible. Campo requerido
        /// </summary>
        public int StockQuantity { get; private set; }

        public Product(string name, decimal price, int stockQuantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(ErrorCatalog.ProductNameEmpty.Code, ErrorCatalog.ProductNameEmpty.Message);
            if (price < 0)
                throw new DomainException(ErrorCatalog.ProductPriceNegative.Code, ErrorCatalog.ProductPriceNegative.Message);
            if (stockQuantity < 0)
                throw new DomainException(ErrorCatalog.ProductStockNegative.Code, ErrorCatalog.ProductStockNegative.Message);

            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }

        /// <summary>
        /// Modifica el nombre del producto.
        /// </summary>
        /// <param name="name">Nombre completo del cliente</param>
        /// <exception cref="DomainException">PRODUCT_NAME_EMPTY: El nombre del producto está vacío y es requerido.</exception>
        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(ErrorCatalog.ProductNameEmpty.Code, ErrorCatalog.ProductNameEmpty.Message);

            Name = name;
        }

        /// <summary>
        /// Modifica el precio del producto.
        /// </summary>
        /// <param name="name">Precio del producto</param>
        /// <exception cref="DomainException">PRODUCT_PRICE_NEGATIVE: El precio del producto no puede ser negativo.</exception>
        public void ChangePrice(decimal price)
        {
            if (price < 0)
                throw new DomainException(ErrorCatalog.ProductPriceNegative.Code, ErrorCatalog.ProductPriceNegative.Message);

            Price = price;
        }

        /// <summary>
        /// Modifica el stock del producto
        /// </summary>
        /// <param name="quantity"></param>
        /// <exception cref="DomainException"></exception>
        public void DecreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new DomainException(ErrorCatalog.ProductQuantityNegative.Code, ErrorCatalog.ProductQuantityNegative.Message);

            if (StockQuantity < quantity)
                throw new DomainException(ErrorCatalog.ProductStockInsufficient.Code, ErrorCatalog.ProductStockInsufficient.Message);

            StockQuantity -= quantity;
        }
    }
}
