namespace Generic_Ecommerce.Application.Features.Products.GetAllProducts
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0m;

        public int StockQuantity { get; set; } = 0;
    }
}
