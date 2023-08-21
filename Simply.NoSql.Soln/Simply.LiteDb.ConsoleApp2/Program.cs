using Simply.LiteDb.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simply.LiteDb.ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LiteDbBusiness business = new LiteDbBusiness())
            {
                var data = business.GetByParameters().ToList();
                Console.WriteLine("Veri sayısı: " + data.Count);
                for (int counter = 0; counter < data.Count; counter++)
                {
                    var model = data[counter];
                    int deleteResult = business.Delete(model.OId);
                    Console.WriteLine($"{model.OId} id ile silinme sonucu: {deleteResult}.");
                }
            }

            Console.ReadKey();
        }
    }
}
