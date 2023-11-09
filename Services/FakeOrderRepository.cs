using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using McDonaldsAPI.Model;

namespace McDonaldsAPI.Services;

//REPOSITORIO PARA TESTES

public class FakeOrderRepository : IOrderRepository
{
    int orderId = 42;
    public Task AddItem(int productId)
    {
        throw new System.NotImplementedException();
    }

    public Task AddItem(int orderId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task CancelOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateOrder(int store)
    {
        return orderId;
    }

    public Task DeliveryOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveItem(int orderId, int productId)
    {
        throw new System.NotImplementedException();
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