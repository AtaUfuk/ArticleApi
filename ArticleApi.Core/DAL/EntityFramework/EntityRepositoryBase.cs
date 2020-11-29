using ArticleApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ArticleApi.Core.DAL.EntityFramework
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public bool AddRange(List<TEntity> entities)
        {
            bool _result = false;
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().AddRange(entities);
                int rslt = context.SaveChanges();
                if (rslt > 0)
                {
                    _result = true;
                }
            }
            return _result;
        }

        public bool Delete(TEntity entity)
        {
            bool _result = false;
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                int rslt = context.SaveChanges();
                if (rslt > 0)
                {
                    _result = true;
                }
            }
            return _result;
        }

        public bool DeleteRange(List<TEntity> entities)
        {
            bool _result = false;
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().RemoveRange(entities);
                int rslt = context.SaveChanges();
                if (rslt > 0)
                {
                    _result = true;
                }
            }
            return _result;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                TEntity _resultEntity;
                if (filter != null)
                {
                    _resultEntity = context.Set<TEntity>().Where(filter).FirstOrDefault();

                }
                else
                {
                    _resultEntity = context.Set<TEntity>().FirstOrDefault();

                }
                return _resultEntity;
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                List<TEntity> _resultEntities;
                if (filter != null)
                {
                    _resultEntities = context.Set<TEntity>().Where(filter).ToList();
                }
                else
                {
                    _resultEntities = context.Set<TEntity>().ToList();
                }
                return _resultEntities;
            }
        }

        public List<TEntity> GetListOrderBy(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> orderbyparam = null, bool isDesc = false)
        {
            using TContext context = new TContext();
            List<TEntity> _resultEntities;
            if (filter != null)
            {
                if (orderbyparam != null && isDesc)
                {
                    _resultEntities = context.Set<TEntity>().OrderByDescending(orderbyparam).ToList();
                }
                else if (orderbyparam != null)
                {
                    _resultEntities = context.Set<TEntity>().Where(filter).OrderBy(orderbyparam).ToList();
                }
                else
                {
                    _resultEntities = context.Set<TEntity>().Where(filter).ToList();
                }
            }
            else
            {
                if (orderbyparam != null && isDesc)
                {
                    _resultEntities = context.Set<TEntity>().OrderByDescending(orderbyparam).ToList();
                }
                else if (orderbyparam != null)
                {
                    _resultEntities = context.Set<TEntity>().OrderBy(orderbyparam).ToList();
                }
                else
                {
                    _resultEntities = context.Set<TEntity>().ToList();
                }
            }
            return _resultEntities;
        }

        public List<TEntity> GetListSomeofThem(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> orderby = null, bool isDesc = false, int skipcount = 0, int takecount = 0)
        {
            using TContext context = new TContext();
            List<TEntity> _resultEntity;
            if (filter != null)
            {
                if (orderby == null)
                {
                    _resultEntity = context.Set<TEntity>().Where(filter).Skip(skipcount).Take(takecount).ToList();
                }
                else
                {
                    if (isDesc)
                    {
                        _resultEntity = context.Set<TEntity>().Where(filter).Skip(skipcount).Take(takecount).OrderByDescending(orderby).ToList();
                    }
                    else
                    {
                        _resultEntity = context.Set<TEntity>().Where(filter).Skip(skipcount).Take(takecount).OrderBy(orderby).ToList();
                    }
                }

            }
            else
            {
                if (orderby == null)
                {
                    _resultEntity = context.Set<TEntity>().Skip(skipcount).Take(takecount).ToList();
                }
                else
                {
                    if (isDesc)
                    {
                        _resultEntity = context.Set<TEntity>().Skip(skipcount).Take(takecount).OrderByDescending(orderby).ToList();
                    }
                    else
                    {
                        _resultEntity = context.Set<TEntity>().Skip(skipcount).Take(takecount).OrderBy(orderby).ToList();
                    }
                }
            }
            return _resultEntity;
        }

        public T ReturnAddedParameter<T>(TEntity entity, string paramname) where T : struct
        {
            using TContext context = new TContext();
            var AddedState = context.Entry(entity);
            AddedState.State = EntityState.Added;
            int _result = context.SaveChanges();
            T id = new T();
            if (_result > 0)
            {
                id = (T)AddedState.OriginalValues[paramname];
            }
            return id;
        }

        public bool Update(TEntity entity)
        {
            bool _result = false;
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                int rslt = context.SaveChanges();
                if (rslt > 0)
                {
                    _result = true;
                }
            }
            return _result;
        }

        public bool UpdateRange(List<TEntity> entities)
        {
            bool _result = false;
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().UpdateRange(entities);
                int rslt = context.SaveChanges();
                if (rslt > 0)
                {
                    _result = true;
                }
            }
            return _result;
        }
    }
}
