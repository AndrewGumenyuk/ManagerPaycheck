using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProductParameterValueService
{
    [ServiceContract]
    public interface IProductParameterValueRepositoryService
    {
        [OperationContract]
        string GetParameterValues();

        [OperationContract]
        void AddParameterValue(string json);

        [OperationContract]
        void DeleteParameterValue(string json);

        [OperationContract]
        void UpdateParameterValue(string json);
    }
}
