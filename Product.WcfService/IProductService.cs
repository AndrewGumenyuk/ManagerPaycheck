using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Repositories.Abstract;

namespace Product.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        int DoWork(int a, int b);

        [OperationContract]
        int DoWork2(int a, int b);


        [OperationContract]
        ProductRepository Product();

        [OperationContract]
        int DoWork3(int a, int b);


    }
}
