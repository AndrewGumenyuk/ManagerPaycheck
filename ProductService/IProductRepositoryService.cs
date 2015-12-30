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
        string GetAll();

        [OperationContract]
        void Add(string json);

        [OperationContract]
        void Delete(string json);

        [OperationContract]
        void Update(string json);
    }
}
