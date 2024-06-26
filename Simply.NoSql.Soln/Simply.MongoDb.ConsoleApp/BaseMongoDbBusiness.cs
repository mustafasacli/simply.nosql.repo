﻿using MongoDB.Driver;
using System;
using System.Globalization;

namespace Simply.MongoDb.ConsoleApp
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A mongo database repository. </summary>
    ///
    /// <remarks>   Msacli, 24.04.2019. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public abstract class BaseMongoDbBusiness<T> : IDisposable where T : class
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Specialised constructor for use only by derived class. </summary>
        ///
        /// <remarks>   Msacli, 24.04.2019. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are null. </exception>
        ///
        /// <param name="databaseName">     Name of the database. </param>
        /// <param name="connectionString"> The connection string. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected BaseMongoDbBusiness(string databaseName, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(databaseName))
                throw new ArgumentNullException(nameof(databaseName));

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            var client = new MongoClient(connectionString);
            this.Collection = client.GetDatabase(databaseName).GetCollection<T>(typeof(T).Name.ToLower(CultureInfo.InvariantCulture));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the collection. </summary>
        ///
        /// <value> The collection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IMongoCollection<T> Collection
        { get; protected set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        /// resources.
        /// </summary>
        ///
        /// <remarks>   Msacli, 24.04.2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Dispose()
        {
            this.Collection = null;
        }
    }
}