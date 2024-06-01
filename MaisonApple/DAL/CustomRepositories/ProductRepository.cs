using System.Linq.Expressions;
using DAO.DAO;
using Entities;

namespace DAL.CustomRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDAOEntities<Product> _dAOProduct;
        private readonly IDAOEntities<ProductColorRelation> _dAOProductColorRelation;

        public ProductRepository(IDAOEntities<Product> daoProduct, IDAOEntities<ProductColorRelation> dAOProductColorRelation)
        {
            _dAOProduct = daoProduct;
            _dAOProductColorRelation = dAOProductColorRelation;
        }

        public async Task<IQueryable<Product>> Query(Expression<Func<Product, bool>> predicate)
        {
            try
            {
                return await _dAOProduct.Query(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public virtual async Task<IQueryable<Product>> Query()
        {
            try
            {
                return await _dAOProduct.Query();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Product> Get(int? id)
        {
            try
            {
                return await _dAOProduct.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Product>> Get()
        {
            try
            {
                return await _dAOProduct.Get();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Add(Product Product)
        {
            try
            {
                await _dAOProduct.Add(Product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Update(Product Product)
        {
            try
            {
                await _dAOProduct.Update(Product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async ValueTask Delete(Product Product)
        {
            try
            {
                var productColorRelations = await _dAOProductColorRelation.Query(r => r.ProductId == Product.Id);
                await _dAOProductColorRelation.Delete(productColorRelations);

                await _dAOProduct.Delete(Product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            try
            {
                var products = (await _dAOProduct.Query(us => us.CategoryId == categoryId, p => p.Images));

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<ProductColor>> GetColorsOfAProduct(int productId)
        {
            try
            {
                var productColorRelations = await _dAOProductColorRelation.Query(r => r.ProductId == productId, r => r.ProductColor);

                var Colors = productColorRelations.Select(r => r.ProductColor);

                return Colors;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
