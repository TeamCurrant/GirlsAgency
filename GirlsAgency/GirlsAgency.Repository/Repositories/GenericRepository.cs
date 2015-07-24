using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Script.Serialization;
using GirlsAgency.Repository.Contracts;

namespace GirlsAgency.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // TODO check for null exception
        private IContext context;

        public GenericRepository(IContext context)
        {
            this.context = context;
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> conditions)
        {
            return GetAll().Where(conditions);
        }

        public T GetById(object id)
        {
            return context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            ChangeState(entity, EntityState.Added);
        }

        public void Delete(T entity)
        {
            ChangeState(entity, EntityState.Deleted);
        }

        public void Update(T entity)
        {
            ChangeState(entity, EntityState.Modified);
        }

        public void Deatch(T entity)
        {
            ChangeState(entity, EntityState.Detached);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public string JsonGrils()
        {
            throw new NotImplementedException();
        }

        public string GetJson()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var entities = this.GetAll();
            var json = jss.Serialize(entities);
            return json;
        }

        public string GetEntityAsJson(T entity)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var json = jss.Serialize(entity);
            return json;
        }

        private void ChangeState(T entity, EntityState state)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = state;
        }
    }
}
