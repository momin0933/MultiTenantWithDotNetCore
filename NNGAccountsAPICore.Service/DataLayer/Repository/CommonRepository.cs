using Microsoft.EntityFrameworkCore;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace NNGAccountsAPICore.Service.DataLayer.Repository
{
    public class CommonRepository : ICommonService, IDisposable
    {
        protected NmlDbContext ctx { get; set; }
        public CommonRepository(NmlDbContext context)
        {
            ctx = context;
        }
        public void Dispose()
        {

        }        
        public virtual int Add<T>(T entity, bool save = true) where T : Base
        {
            ctx.Set<T>().Add(entity);
            if (save)
            {
                Save();
            }
            return entity.Id;
        }
        public virtual int AddRange<T>(List<T> entity, bool save = true) where T : Base
        {
            ctx.Set<T>().AddRange(entity);
            if (save)
            {
                Save();
            }
            return entity.FirstOrDefault().Id;
        }
        public virtual IEnumerable<T> GetAll<T>() where T : Base
        {
            return ctx.Set<T>().AsEnumerable();
        }
        public virtual IQueryable<T> Query<T>() where T : Base
        {
            return ctx.Set<T>().AsQueryable<T>();
        }
        public virtual T Get<T>(int id) where T : Base
        {
            return ctx.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual int Update<T>(T entity, bool save = true) where T : Base
        {
            ctx.Set<T>().Attach(entity);
            ctx.Entry(entity).State = EntityState.Modified;
            if (save)
            {
                Save();
            }
            return entity.Id;           
        }
        public virtual int UpdateByProperty<T>(T entity,string PropertyName="", bool save = true) where T : Base
        {
            ctx.Set<T>().Attach(entity);
            //x.GetType().GetProperty("RequisitionId").GetValue(x) == RrId
            ctx.Entry(entity).Property(x => x.GetType().GetProperty(PropertyName).GetValue(x)).IsModified = true; 
            if (save)
            {
                Save();
            }
            return entity.Id;
        }
        public virtual bool Remove<T>(T entity, bool save = true) where T : Base
        {
            ctx.Set<T>().Attach(entity);
            ctx.Entry(entity).State = EntityState.Deleted;
            //ctx.Set<T>().Remove(entity);
            if (save)
                return Save() > 0;
            return false;          
        }

        public virtual bool RemoveById<T>(int id, bool save = true) where T : Base
        {
            var entity = Get<T>(id);
            return Remove(entity, save);
        }     
        public virtual long Save()
        {
            ctx.ChangeTracker.AutoDetectChangesEnabled = false;
            return ctx.SaveChanges();   
        }
        public int AddIfNotExists<T>(T entity, Expression<Func<T, bool>> predicate = null) where T : Base
        {
                ctx.ChangeTracker.LazyLoadingEnabled = false;
                var _entity = ctx.Set<T>();
                var exists = predicate != null ? _entity.Any(predicate) : _entity.Any();
                //_entity.Add(entity);
                int ReturnId = exists ? 0 : 1;
                return ReturnId;           
        }
    }

    //public class CommonService<T> : ICommonService<T> where T : class
    //{
    //   // public ModelDbContext db = new ModelDbContext();
    //    public DbContext db;
    //    public CommonService(DbContext db1)
    //    {
    //        db = db1;
    //    }

    //    public CommonService()
    //    {           
    //    }
    //    public DbSet<T> GetTable()
    //    { return db.Set<T>(); }

    //    public IEnumerable<T> Get()
    //    {
    //        return GetTable().ToList();
    //    }
    //    public int Add(T entity)
    //    {      
    //        GetTable().Add(entity);
    //        int ReturnId = db.SaveChanges();
    //        //int ReturnId = 0;

    //        return ReturnId;
    //    }
    //    public bool Update(T entity)
    //    {
    //        GetTable().Attach(entity);
    //        db.Entry(entity).State = EntityState.Modified;
    //        return db.SaveChanges() > 0;
    //    }

    //    public bool Remove(T entity)
    //    {
    //        GetTable().Attach(entity);
    //        db.Entry(entity).State = EntityState.Deleted;
    //        return db.SaveChanges() > 0;
    //    }
    //}
}