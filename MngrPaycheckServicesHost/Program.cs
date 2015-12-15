using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ProductParameterService;
using ProductService;
using ProductTypeService;

namespace MngrPaycheckServicesHost
{
    public class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
            using (ServiceHost host = new ServiceHost(typeof(ProductRepositoryService)))
            {
                host.Open();
                Console.WriteLine("Starting | " + host.Description.Name + " | " + DateTime.Now);
            }

            using (ServiceHost host = new ServiceHost(typeof(ProductTypeRepositoryService)))
            {
                host.Open();
                Console.WriteLine("Starting | " + host.Description.Name + " | " + DateTime.Now);
            }

            using (ServiceHost host = new ServiceHost(typeof(ProductParameterRepositoryService)))
            {
                host.Open();
                Console.WriteLine("Starting | " + host.Description.Name + " | " + DateTime.Now);
            }

            Console.ReadLine();
        }
    }
}
