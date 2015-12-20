using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductTypeService
{
    [ServiceContract]
    public interface IProductTypeRepositoryService
    {
        [OperationContract]
        string GetProductTypes();

        [OperationContract]
        void AddProductType(string json);

        [OperationContract]
        void DeleteProductType(string json);

        [OperationContract]
        void UpdateProductTypes(string json);
    }
}
