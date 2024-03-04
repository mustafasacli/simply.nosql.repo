using Simply.LiteDb.Core;
using Simply.NoSql.Business.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Simply.LiteDb.Business
{
    /// <summary>
    /// The lite db business.
    /// </summary>
    public class LiteDbBusiness : BaseLiteDbBusiness<SampleModel>, ISimplyNoSqlBusiness<SampleModel>
    {
        public LiteDbBusiness() : base("Filename=appLogDb.db;")//base("Filename=C:\\appLogDb.db;")
        { }

        public int Delete(SampleModel model)
        {
            int deleteResult = base.Collection.DeleteMany(q => q.OId == model.OId);
            return deleteResult;
        }

        public int Delete(string oid)
        {
            int deleteResult = base.Collection.DeleteMany(q => q.OId == oid);
            return deleteResult;
        }

        public SampleModel GetById<TId>(TId id)
        {
            SampleModel model = base.Collection.FindOne(q => q.OId == id.ToString());
            return model;
        }

        public IEnumerable<SampleModel> GetByParameters(IDictionary<string, object> parameterPairs = null)
        {
            IEnumerable<SampleModel> data = base.Collection
                .FindAll()
                .OrderByDescending(q => q.CreatedOnTimestamp);

            return data;
        }

        public string Save(SampleModel model)
        {
            var insertResult = base.Collection.Insert(model);
            return insertResult.IsString ? insertResult.AsString : insertResult.RawValue?.ToString() ?? string.Empty;
        }

        public int Update(SampleModel model)
        {
            bool updateResult = base.Collection.Update(model);
            return updateResult ? 1 : 0;
        }
    }
}