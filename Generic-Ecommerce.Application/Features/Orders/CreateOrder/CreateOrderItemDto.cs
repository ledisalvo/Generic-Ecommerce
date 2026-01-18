namespace Generic_Ecommerce.Application.Features.Orders.CreateOrder
{
    public record CreateOrderItemDto(
    Guid ProductId,
    int Quantity
);
}
