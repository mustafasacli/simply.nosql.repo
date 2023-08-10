using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Simply.NoSql.Business.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB;

namespace Simply.MongoDb.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleModel model = new SampleModel()
            {
                OId = Guid.NewGuid().ToString(),
                //Id = 101,
                FirstName = "Mustafa",
                LastName = "Sacli",
                CreatedOn = DateTime.UtcNow.AddHours(3),
                CreatedOnTimestamp = DateTime.UtcNow.AddHours(3).Ticks
            };

            using (MongoDbBusiness business = new MongoDbBusiness())
            {
                var result = business.Save(model);
                Console.WriteLine("Result: " + result);
                var model2 = business.GetById<string>(model.OId);
                Console.WriteLine(model2.CreatedOn.ToString("dd-MM-yyyy HH:mm:ss.ffffff"));
                Console.WriteLine(((new DateTime(1970, 1, 1)).AddTicks(model2.CreatedOnTimestamp)).ToString("dd-MM-yyyy HH:mm:ss.ffffff"));
            }

            Console.ReadKey();
        }
    }

    public class SampleModel
    {
        [BsonId]
        public string OId
        { get; set; }

        //public long Id
        //{ get; set; }

        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }

        public DateTime CreatedOn
        { get; set; }

        public long CreatedOnTimestamp
        { get; set; }
    }

    /// <summary>
    /// The mongo db business.
    /// </summary>
    public class MongoDbBusiness : BaseMongoDbBusiness<SampleModel>, ISimplyNoSqlBusiness<SampleModel>
    {
        public MongoDbBusiness() : base("errorLogDb", //"mongodb://127.0.0.1:27017")
        ConfigurationManager.ConnectionStrings["errorLogDbConnStr"].ConnectionString)
        {
        }

        public int Delete(SampleModel model)
        {
            var deleteResult = Collection.DeleteOne(q => q.OId == model.OId);
            return (int)deleteResult.DeletedCount;
        }

        public int Delete(string oid)
        {
            var deleteResult = Collection.DeleteOne(q => q.OId == oid);
            return (int)deleteResult.DeletedCount;
        }

        public SampleModel GetById<TId>(TId id)
        {
            var result = Collection.Find(q => q.OId == id.ToString()).FirstOrDefault();
            return result;
        }

        public IEnumerable<SampleModel> GetByParameters(IDictionary<string, object> parameterPairs = null)
        {
            throw new NotImplementedException();
        }

        public string Save(SampleModel model)
        {
            model.CreatedOn = DateTime.Now;
            model.CreatedOnTimestamp = model.CreatedOn.Ticks;
            base.Collection.InsertOne(model);
            return model.CreatedOnTimestamp.ToString();
        }

        public int Update(SampleModel model)
        {
            var filter = Builders<SampleModel>.Filter.Eq(s => s.OId, model.OId);
            var replaceOneResult = this.Collection.ReplaceOne(filter, model);

            return (int)replaceOneResult.ModifiedCount;
        }
    }
}
