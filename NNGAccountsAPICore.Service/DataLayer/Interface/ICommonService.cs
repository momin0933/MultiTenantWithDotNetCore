using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.DataLayer.Interface
{
    public interface ICommonService
    {
        int Add<T>(T entity, bool save = true) where T : Base;
        int AddRange<T>(List<T> entity, bool save = true) where T : Base;
        int Update<T>(T entity, bool save = true) where T : Base;
        int UpdateByProperty<T>(T entity, string PropertyName = "", bool save = true) where T : Base;
        bool Remove<T>(T entity, bool save = true) where T : Base;
        bool RemoveById<T>(int id, bool save = true) where T : Base;
        T Get<T>(int id) where T : Base;
        IEnumerable<T> GetAll<T>() where T : Base;
        IQueryable<T> Query<T>() where T : Base;
        int AddIfNotExists<T>(T entity, Expression<Func<T, bool>> predicate = null) where T : Base;
        long Save();
    }
}
