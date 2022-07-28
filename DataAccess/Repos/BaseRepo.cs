using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class BaseRepo<T>: IRepo<T>,IDisposable where T: EntityBase, new()
    {
        private readonly DbSet<T> _table;

        private readonly LibraryDbContext _db;
        protected LibraryDbContext Context => _db;
        public BaseRepo(LibraryDbContext context)
        {
            _db = context;
            _table = _db.Set<T>();
}

        public int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }

        public int Update(T entity)
        {
            _table.Update(entity);
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public T GetOne(int? id) => _table.Find(id);

        public List<T> GetSome(Expression<Func<T, bool>> where) => _table.Where(where).ToList();

        public List<T> GetAll() => _table.ToList();

        public List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending) 
            => (ascending ? _table.OrderBy(orderBy) : _table.OrderByDescending(orderBy)).ToList();

        public void Dispose()
        {
            _db?.Dispose();
        }

        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
        }
    }
}
