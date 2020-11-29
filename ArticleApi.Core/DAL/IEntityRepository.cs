using ArticleApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ArticleApi.Core.DAL
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        List<TEntity> GetListOrderBy(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> orderbyparam = null, bool isDesc = false);
        void Add(TEntity entity);
        bool AddRange(List<TEntity> entities);
        bool Update(TEntity entity);
        bool UpdateRange(List<TEntity> entities);
        bool Delete(TEntity entity);
        bool DeleteRange(List<TEntity> entities);
        T ReturnAddedParameter<T>(TEntity entity, string paramname) where T : struct;
    }
}
