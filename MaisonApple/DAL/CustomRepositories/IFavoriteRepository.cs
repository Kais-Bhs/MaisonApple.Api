using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.CustomRepositories
{
    public interface IFavoriteRepository
    {
        Task<IQueryable<Favoris>> Query(Expression<Func<Favoris, bool>> predicate);
        Task<IQueryable<Favoris>> Query();

        Task<Favoris> Get(int? id);

        Task<IEnumerable<Favoris>> Get();

        Task Add(Favoris Favoris);

        Task Update(Favoris Favoris);

        ValueTask Delete(Favoris Favoris);
        Task<List<Product>> GetFavoriteByUser(string userId);
    }
}
