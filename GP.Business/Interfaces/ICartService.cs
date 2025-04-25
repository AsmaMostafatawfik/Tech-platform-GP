using GP.Data.Entities;

public interface ICartService
{
    Task<List<ShoppingCart>> GetCartItemsAsync(string userId);
    Task AddToCartAsync(string userId, int productId);
    Task RemoveFromCartAsync(string userId, int productId);
    Task IncreaseQuantityAsync(string userId, int productId);
    Task DecreaseQuantityAsync(string userId, int productId);
    Task ClearCartAsync(string userId);
    Task<decimal> GetTotalAmountAsync(string userId); // Get the total price
}
