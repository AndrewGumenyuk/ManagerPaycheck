using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProductParameterService
{
    [ServiceContract]
    public interface IProductParameterRepositoryService
    {
        [OperationContract]
        string GetProductParameters();

        [OperationContract]
        void AddProductParameter(string json);

        [OperationContract]
        void DeleteProductParameter(string json);

        [OperationContract]
        void UpdateProductParameter(string json);
    }
}
