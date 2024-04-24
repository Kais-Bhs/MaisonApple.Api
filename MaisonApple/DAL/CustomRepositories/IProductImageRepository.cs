using System.Linq.Expressions;
using Entities;

namespace DAL.CustomRepositories
{
    public interface IProductImageRepository
    {
        Task<IQueryable<ProductImage>> Query(Expression<Func<ProductImage, bool>> predicate);
        Task<IQueryable<ProductImage>> Query();
        Task<ProductImage> Get(int? id);
        Task<IEnumerable<ProductImage>> Get();
        Task Add(ProductImage ProductImage);
        Task Update(ProductImage ProductImage);
        ValueTask Delete(ProductImage ProductImage);
        Task<IEnumerable<ProductImage>> GetProductImagesByProductId(int productId);
    }
}
