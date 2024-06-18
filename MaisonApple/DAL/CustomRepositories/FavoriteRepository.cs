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
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly IDAOEntities<Favoris> _dAOFavoris;

        public FavoriteRepository(IDAOEntities<Favoris> daoFavoris)
        {
            _dAOFavoris = daoFavoris;
        }

        public async Task<IQueryable<Favoris>> Query(Expression<Func<Favoris, bool>> predicate)
        {
            try
            {
                return await _dAOFavoris.Query(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public virtual async Task<IQueryable<Favoris>> Query()
        {
            try
            {
                return await _dAOFavoris.Query();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Favoris> Get(int? id)
        {
            try
            {
                return await _dAOFavoris.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Favoris>> Get()
        {
            try
            {
                return await _dAOFavoris.Get();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Add(Favoris Favoris)
        {
            try
            {
                await _dAOFavoris.Add(Favoris);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Update(Favoris Favoris)
        {
            try
            {
                await _dAOFavoris.Update(Favoris);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async ValueTask Delete(Favoris Favoris)
        {
            try
            {
                await _dAOFavoris.Delete(Favoris);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<List<Product>> GetFavoriteByUser(string userId)
        {
            try
            {
                var favoriteByUser = (await _dAOFavoris.Query(f => f.UserId == userId, f => f.Product)).ToList();

                var products = (favoriteByUser.Select(x => x.Product)).ToList();

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
