using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories.Abstract;

namespace Product.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        public int DoWork(int a, int b)
        {
            return a + b;
        }
        public int DoWork2(int a, int b)
        {
            return a + b;
        }

        public ProductRepository Product()
        {
            return new ProductRepository(MngPaycheckContext.Instance);
        }

        public int DoWork3(int a, int b)
        {
            return a + b;
        }


    }
}
