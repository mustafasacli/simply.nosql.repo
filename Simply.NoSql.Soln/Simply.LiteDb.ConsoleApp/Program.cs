using Simply.LiteDb.Business;
using System;
using System.Linq;

namespace Simply.LiteDb.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (LiteDbBusiness business = new LiteDbBusiness())
            {
                for (int counter = 0; counter < 100; counter++)
                {
                    DateTime now = DateTime.Now;
                    SampleModel model = new SampleModel()
                    {
                        OId = Guid.NewGuid().ToString(),
                        //Id = 101,
                        FirstName = "Mustafa",
                        LastName = "Sacli",
                        CreatedOn = now,
                        CreatedOnTimestamp = now.Ticks,
                        Details = new string[] { "ali", "veli", "serhan" }
                    };
                    var result = business.Save(model);
                    Console.WriteLine("Result: " + result);
                    var model2 = business.GetById<string>(model.OId);
                    Console.WriteLine(model2.CreatedOn.ToString("dd-MM-yyyy HH:mm:ss.ffffff"));
                    Console.WriteLine(((new DateTime()).AddTicks(model2.CreatedOnTimestamp)).ToString("dd-MM-yyyy HH:mm:ss.ffffff"));
                }
            }

            Console.ReadKey();
        }
    }
}