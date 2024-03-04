using LiteDB;
using System;

namespace Simply.LiteDb.Core
{
    /// <summary>
    /// The base lite db business.
    /// </summary>
    public abstract class BaseLiteDbBusiness<T> : IDisposable where T : class
    {
        /// <summary>
        /// LiteDatabase object instance.
        /// </summary>
        protected LiteDatabase database;

        /// <summary>
        /// Database object Collection.
        /// </summary>
        protected readonly ILiteCollection<T> liteCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLiteDbBusiness"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="mapper">The mapper.</param>
        protected BaseLiteDbBusiness(string connectionString, BsonMapper mapper = null)
        {
            database = new LiteDatabase(connectionString, mapper);
            Collection = database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
            liteCollection = database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }

        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        protected ILiteCollection<T> Collection
        { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            database?.Dispose();
        }

        /// <summary>
        /// Rebuild all database to remove unused pages - reduce data file
        /// </summary>
        public void Rebuild()
        {
            database?.Rebuild();
        }
    }
}