using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MngrPaycheck.Entity;

namespace ProductService
{
    [ServiceContract]
    public interface IProductRepositoryService
    {
        [OperationContract]
        string GetProducts();

        [OperationContract]
        void AddProduct(string json);

        [OperationContract]
        void DeleteProduct(string json);

        [OperationContract]
        void UpdateProducts(string json);
    }
}
