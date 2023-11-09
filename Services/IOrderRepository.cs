using System.Collections.Generic;
using System.Threading.Tasks;
using mcdonalds_api.Model;
namespace McDonaldsAPI.Services;


public interface IOrderRepository
{
    Task<int> CreateOrder(int store);
    Task CancelOrder(string orderId);
    Task<List<Product>> GetMenu(int orderId);
    Task<List<Product>> GetOrderItems(int orderId);
    Task AddItem(int productId);
    Task RemoveItem(int orderId, int productId);
    Task FinishOrder(int orderId);
    Task DeliveryOrder(int orderId);
}