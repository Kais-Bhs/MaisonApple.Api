using System.Linq.Expressions;
using Entities;

namespace DAL.CustomRepositories
{
    public interface IProductRepository
    {
        Task<IQueryable<Product>> Query(Expression<Func<Product, bool>> predicate);
        Task<IQueryable<Product>> Query();
        Task<Product> Get(int? id);
        Task<IEnumerable<Product>> Get();
        Task Add(Product Product);
        Task Update(Product Product);
        ValueTask Delete(Product Product);
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
    }
}
