﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Script.Serialization;
using GirlsAgency.Model;
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

        public Customer GetCustomer(int customerId)
        {
            return context.Customers.FirstOrDefault(c => c.Id == customerId);
        }

        public List<int> GetCustomerByGirlId(int girlId)
        {
            return this.context.Orders.Where(o => o.GirlId == girlId).Select(c => c.CustomerId).ToList();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> conditions)
        {
            return GetAll().Where(conditions);
        }

        public T GetById(object id)
        {
            return context.Set<T>().Find(id);
        }

        public Girl GetByName(string firstName, string lastName)
        {
            return context.Girls.FirstOrDefault(g => g.FirstName == firstName && g.LastName == lastName);
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


        // TODO DELETE THIS SHIT
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
