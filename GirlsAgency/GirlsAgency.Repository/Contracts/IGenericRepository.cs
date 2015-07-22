namespace GirlsAgency.Repository.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Method that retuns all data from database by given model queyable with linq
        /// </summary>
        /// <returns>Queryable</returns>
        IQueryable<T> GetAll();


        /// <summary>
        /// Method that sarches and retuns data from database by condition
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns>Queryable</returns>
        IQueryable<T> Search(Expression<Func<T, bool>>conditions);


        /// <summary>
        /// Metheod that retuns one Model from database. If nothin found - returns Null
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Model T</returns>
        T GetById(object id);

        /// <summary>
        /// Adds new entity into database
        /// </summary>
        /// <param name="entity">Model T</param>
        void Add(T entity);

        /// <summary>
        /// Deletes entity from database
        /// </summary>
        /// <param name="entity">Model T</param>
        void Delete(T entity);


        /// <summary>
        /// Updates entity into database
        /// </summary>
        /// <param name="entity">Model T</param>
        void Update(T entity);

        /// <summary>
        /// Detaches entity from database
        /// </summary>
        /// <param name="entity">Model T</param>
        void Deatch(T entity);

        /// <summary>
        /// Write changes into database. Needed to be invoked after other methods
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Returns all entitys from database as JSON
        /// </summary>
        /// <returns>String</returns>
        string GetJson();

        /// <summary>
        /// Returns JSON from specific Entity
        /// </summary>
        /// <param name="entity">T model</param>
        /// <returns>string</returns>
        string GetEntityAsJson(T entity);
    }
}
