using System.Linq.Expressions;
using DAO.DAO;
using Entities;

namespace DAL.CustomRepositories
{
    internal class ProductImageRepository : IProductImageRepository
    {
        private readonly IDAOEntities<ProductImage> _dAOProductImage;

        public ProductImageRepository(IDAOEntities<ProductImage> daoProductImage)
        {
            _dAOProductImage = daoProductImage;
        }

        public async Task<IQueryable<ProductImage>> Query(Expression<Func<ProductImage, bool>> predicate)
        {
            try
            {
                return await _dAOProductImage.Query(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public virtual async Task<IQueryable<ProductImage>> Query()
        {
            try
            {
                return await _dAOProductImage.Query();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ProductImage> Get(int? id)
        {
            try
            {
                return await _dAOProductImage.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<ProductImage>> Get()
        {
            try
            {
                return await _dAOProductImage.Get();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Add(ProductImage ProductImage)
        {
            try
            {
                await _dAOProductImage.Add(ProductImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Update(ProductImage ProductImage)
        {
            try
            {
                await _dAOProductImage.Update(ProductImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async ValueTask Delete(ProductImage ProductImage)
        {
            try
            {
                await _dAOProductImage.Delete(ProductImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<ProductImage>> GetProductImagesByProductId(int productId)
        {
            try
            {
                var ProductImages = (await _dAOProductImage.Query(us => us.ProductId == productId));

                return ProductImages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
