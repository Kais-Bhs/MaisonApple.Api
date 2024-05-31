using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAO.DAO;
using Entities;

namespace DAL.CustomRepositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly IDAOEntities<Order> _dAOOrder;

        public OrderRepository(IDAOEntities<Order> daoOrder)
        {
            _dAOOrder = daoOrder;
        }

        public async Task<IQueryable<Order>> Query(Expression<Func<Order, bool>> predicate)
        {
            try
            {
                return await _dAOOrder.Query(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public virtual async Task<IQueryable<Order>> Query()
        {
            try
            {
                return await _dAOOrder.Query();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Order> Get(int? id)
        {
            try
            {
                return await _dAOOrder.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Order>> Get()
        {
            try
            {
                return await _dAOOrder.Get();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Add(Order Order)
        {
            try
            {
                await _dAOOrder.Add(Order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Update(Order Order)
        {
            try
            {
                await _dAOOrder.Update(Order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async ValueTask Delete(Order Order)
        {
            try
            {
                await _dAOOrder.Delete(Order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersByCommanId(int commandId)
        {
            try
            {
                var Orders = (await _dAOOrder.Query(us => us.PaymentId == commandId, us => us.Product ));

                return Orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
