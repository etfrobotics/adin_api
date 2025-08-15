using adin_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace adin_api.Data.iRepository
{
    public interface IGenericRepository<T> where T: class
    {
        Task<List<T>> GetAll(
            Expression<Func<T, bool>> expression= null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
            );

        Task<IPagedList<T>> GetAll(
            DTOs.RequestParams requestParams,
            Expression<Func<T, bool>> expression = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            List<string> includes = null
            );

        Task<T> Get(
            Expression<Func<T, bool>> expression = null,
            List<string> includes = null
            );

        Task Insert(T entity);

        Task InsertRange(IEnumerable<T> entities);

        Task Delete(int id);

        Task Delete(string id);

        Task DeleteRange(IEnumerable<T> entities);

        void Update(T entity);
    }
}
