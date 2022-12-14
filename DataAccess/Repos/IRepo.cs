using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public interface IRepo<T>
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        T GetOne(int? id);
        List<T> GetSome(Expression<Func<T, bool>> where);
        List<T> GetAll();
        List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending);
    }
}
