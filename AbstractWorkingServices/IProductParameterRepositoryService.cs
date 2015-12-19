using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MngrPaycheck.Accessors.Abstract;

namespace AbstractWorkingServices
{
    [ServiceContract]
    public interface IProductParameterRepositoryService: IBaseService
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