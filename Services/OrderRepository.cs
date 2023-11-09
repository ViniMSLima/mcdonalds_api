using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using McDonaldsAPI.Model;

namespace McDonaldsAPI.Services;

public class OrderRepository : IOrderRepository
{
    private readonly McDataBaseContext ctx;
    public OrderRepository(McDataBaseContext ctx)
        => this.ctx = ctx;

    public async Task<ClientOrder> GetOrder(int orderId)
    {
        var orders =
            from order in ctx.ClientOrders
            where order.Id == orderId
            select order;

        return await orders.FirstOrDefaultAsync();
    }

    public async Task<int> CreateOrder(int storeId)
    {
        var selectedStore =
            from store in ctx.Stores
            where store.Id == storeId
            select store;
            
        if (!selectedStore.Any())
            throw new Exception("Store don't exist.");

        var clientOrder = new ClientOrder();
        clientOrder.StoreId = storeId;
        clientOrder.OrderCode = "abcd1234";
        
        ctx.Add(clientOrder);
        await ctx.SaveChangesAsync();

        return clientOrder.Id;
    }
    
    public async Task CancelOrder(int orderId)
    {
        var currentOrder = await GetOrder(orderId);

        if(currentOrder is null)
            throw new Exception("Order don't exist!");

        // var currentOrder = await GetOrder(orderId) ?? throw new Exception("Order don't exist!");

        ctx.Remove(currentOrder);
        await ctx.SaveChangesAsync();
    }

    public async Task AddItem(int orderId, int productId)
    {
        var currentOrder = await GetOrder(orderId) ?? throw new Exception("Order don't exist!");

        var products =
            from product in ctx.Products
            where product.Id == productId
            select product;

        var selectedProduct = products
            .FirstOrDefaultAsync();

        if(selectedProduct is null)
            throw new Exception("product don't exist");

        var item = new ClientOrderItem();
        item.ClientOrderId = orderId;
        item.ProductId = productId;

        ctx.Add(item);
        await ctx.SaveChangesAsync();

    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveItem(int orderId, int productId)
    {
        var currentOrder = await GetOrder(orderId);

        if(currentOrder is null)
            throw new Exception("Order don't exist!");

        var products =
            from product in currentOrder.ClientOrderItems
            where product.Id == productId
            select product;

        if(products is null)
            throw new Exception("product is not in ClientOrder!");

       ctx.Remove(products.FirstOrDefault());
       await ctx.SaveChangesAsync();

    }

    public async Task FinishOrder(int orderId)
    {
        var currentOrder = await GetOrder(orderId);

        if(currentOrder is null)
            throw new Exception("Order don't exist!");

        currentOrder.FinishMoment = DateTime.Now;
    }

    public Task DeliveryOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    Task<List<Product>> IOrderRepository.GetMenu(int orderId)
    {
        throw new NotImplementedException();
    }

    Task<List<Product>> IOrderRepository.GetOrderItems(int orderId)
    {
        throw new NotImplementedException();
    }


}