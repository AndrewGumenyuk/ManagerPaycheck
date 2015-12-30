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
        string GetAll();

        [OperationContract]
        void Add(string json);

        [OperationContract]
        void Delete(string json);

        [OperationContract]
        void Update(string json);
    }
}
