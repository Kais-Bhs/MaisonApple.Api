﻿using System.Linq.Expressions;
using Entities;

namespace DAL.CustomRepositories
{
    public interface IOrderRepository
    {
        Task<IQueryable<Order>> Query(Expression<Func<Order, bool>> predicate);
        Task<IQueryable<Order>> Query();
        Task<Order> Get(int? id);
        Task<IEnumerable<Order>> Get();
        Task Add(Order Order);
        Task Update(Order Order);
        ValueTask Delete(Order Order);
        Task<IEnumerable<Order>> GetOrdersByCommanId(int commandId);
    }
}
