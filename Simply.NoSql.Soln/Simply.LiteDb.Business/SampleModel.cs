using System;

namespace Simply.LiteDb.Business
{
    public class SampleModel
    {
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

        public string[] Details
        { get; set; }
    }
}