using System.Collections.Generic;

namespace Simply.NoSql.Business.Core.Interfaces
{
    public interface ISimplyNoSqlBusiness<TObject> where TObject : class
    {
        /// <summary>
        /// Saves the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A string.</returns>
        string Save(TObject model);

        /// <summary>
        /// Updates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>An int.</returns>
        int Update(TObject model);

        /// <summary>
        /// Gets the model by ıd.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A TObject.</returns>
        TObject GetById<TId>(TId id);


        /// <summary>
        /// Deletes the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>An int.</returns>
        int Delete(TObject model);

        /// <summary>
        /// Deletes the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>An int.</returns>
        int Delete(string oid);

        /// <summary>
        /// Gets the model by parameters.
        /// </summary>
        /// <param name="parameterPairs">The parameter pairs.</param>
        /// <returns>A list of TObjects.</returns>
        IEnumerable<TObject> GetByParameters(IDictionary<string, object> parameterPairs = null);
    }
}
