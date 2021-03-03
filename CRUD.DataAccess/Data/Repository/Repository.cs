using CRUD.DataAccess.Data.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        void IRepository<T>.Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }

        T IRepository<T>.Get(int id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }

        IEnumerable<T> IRepository<T>.GetAll(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties)
        {
            try
            {
                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query.Where(filter);
                }

                if (includeProperties != null) {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                return query.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }

        T IRepository<T>.GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeProperties)
        {
            try
            {
                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query.Where(filter);
                }

                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }

                return query.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }

        void IRepository<T>.Remove(int id)
        {
            try
            {
                T entity = dbSet.Find(id);
                dbSet.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }

        void IRepository<T>.Remove(T entity)
        {
            try
            {
                dbSet.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }

        void IRepository<T>.RemoveRange(IEnumerable<T> entity)
        {
            try
            {
                dbSet.RemoveRange(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }
    }
}
