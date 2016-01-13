using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BuyerService;
using ProductParameterService;
using ProductService;
using ProductTypeService;
using PurchaseProductService;
using PurchaseService;

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

            using (ServiceHost host = new ServiceHost(typeof(ProductParameterRepositoryService)))
            {
                host.Open();
                Console.WriteLine("Starting | " + host.Description.Name + " | " + DateTime.Now);
            }

            using (ServiceHost host = new ServiceHost(typeof(BuyerRepositoryService)))
            {
                host.Open();
                Console.WriteLine("Starting | " + host.Description.Name + " | " + DateTime.Now);
            }

            using (ServiceHost host = new ServiceHost(typeof(PurchaseProductRepositoryService)))
            {
                host.Open();
                Console.WriteLine("Starting | " + host.Description.Name + " | " + DateTime.Now);
            }

            using (ServiceHost host = new ServiceHost(typeof(PurchaseRepositoryService)))
            {
                host.Open();
                Console.WriteLine("Starting | " + host.Description.Name + " | " + DateTime.Now);
            }

            Console.ReadLine();
        }
    }
}
