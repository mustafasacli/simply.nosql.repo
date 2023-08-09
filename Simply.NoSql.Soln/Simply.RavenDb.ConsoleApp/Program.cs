using Simply.RavenDb.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simply.RavenDb.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleModel model = new SampleModel()
            {
                OId = Guid.NewGuid().ToString(),
                Id = 101,
                FirstName = "Mustafa",
                LastName = "Sacli",
                CreatedOn = DateTime.Now,
                CreatedOnTimestamp = DateTime.Now.Ticks
            };

            using (RavenDbBusiness<SampleModel> business =
                new RavenDbBusiness<SampleModel>("SampleDb1", "http://localhost:8080"))
            {
                var result = business.Save(model);
                Console.WriteLine("Result: " + result);
            }

            Console.ReadKey();
        }
    }

    public class SampleModel
    {

        public string OId
        { get; set; }

        public long Id
        { get; set; }

        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }

        public DateTime CreatedOn
        { get; set; }

        public long CreatedOnTimestamp
        { get; set; }
    }
}
