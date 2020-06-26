using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        const string filePath = "types.txt";
        static void Main(string[] args)
        {
            try
            {
                IInstanceService instanceService = new InstanceService();

                var types = instanceService.GetInstances<Vehicle>();
                var sortedTypes = types.OrderBy(x => x.Name);
                foreach (var type in sortedTypes)
                {
                    Console.WriteLine(type.Name);
                }
                Console.WriteLine("== end ==");

                //iTypesToDiskService diskService = new TypesToDiskService();
                //await diskService.SaveTypes(types, filePath);

                //var search = instanceService.SearchTypesByName<Vehicle>("c");
                //foreach (var item in search)
                //{
                //    Console.WriteLine(item);
                //}

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled exception occured!");
                //loger.Log(ex);
            }
        }
    }
}
