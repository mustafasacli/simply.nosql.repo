﻿using Simply.LiteDb.Business;
using System;
using System.Linq;

namespace Simply.LiteDb.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (int counter = 0; counter < 100; counter++)
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
                using (LiteDbBusiness business = new LiteDbBusiness())
                {
                    var result = business.Save(model);
                    Console.WriteLine("Result: " + result);
                    var model2 = business.GetById<string>(model.OId);
                    Console.WriteLine(model2.CreatedOn.ToString("dd-MM-yyyy HH:mm:ss.ffffff"));
                    Console.WriteLine(((new DateTime(1970, 1, 1)).AddTicks(model2.CreatedOnTimestamp)).ToString("dd-MM-yyyy HH:mm:ss.ffffff"));
                }
            }

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