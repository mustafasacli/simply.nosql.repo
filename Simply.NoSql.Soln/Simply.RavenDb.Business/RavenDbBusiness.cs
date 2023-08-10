using Simply.NoSql.Business.Core.Interfaces;
using Simply.RavenDb.Core;
using System;
using System.Collections.Generic;

namespace Simply.RavenDb.Business
{
    /// <summary>
    /// The raven db business.
    /// </summary>
    public class RavenDbBusiness<T> : BaseRavenDbBusiness<T>, ISimplyNoSqlBusiness<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RavenDbBusiness"/> class.
        /// </summary>
        /// <param name="defaultDatabaseName">The default database name.</param>
        /// <param name="dbServerUrl">The db server url.</param>
        public RavenDbBusiness(string defaultDatabaseName, string dbServerUrl)
            : base(defaultDatabaseName, dbServerUrl)
        {
        }

        /// <summary>
        /// Deletes the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>An int.</returns>
        public int Delete(T model)
        {
            base.DeleteDocument(model);
            return 1;
        }

        public int Delete(string oid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the model by ıd.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A T.</returns>
        public T GetById<TId>(TId id)
        {
            var model = base.GetDocument(id.ToString());
            return model;
        }

        public IEnumerable<T> GetByParameters(IDictionary<string, object> parameterPairs = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A string.</returns>
        public string Save(T model)
        {
            base.AddDocument(model);
            return "1";
        }

        /// <summary>
        /// Updates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>An int.</returns>
        public int Update(T model)
        {
            base.UpdateDocument(model);
            return 1;
        }
    }
}