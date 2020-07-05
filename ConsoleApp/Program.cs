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
                var instanceService = new InstanceService();

                var instances = instanceService.GetInstances<Vehicle>();
                var types = instanceService.GetTypes<Vehicle>();
                var sortedTypes = types.OrderBy(x => x.Name);
                foreach (var type in types)
                {
                    Console.WriteLine(type.Name);
                }
                foreach (var item in instances)
                {
                    Console.WriteLine(item.ToString());
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
