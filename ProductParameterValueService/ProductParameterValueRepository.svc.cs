using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace ProductParameterValueService
{
    public class ProductParameterValueRepository : IProductParameterValueRepository
    {
        private WrapperProductParameterValue _wrapperProductParameterValue;

        public ProductParameterValueRepository()
        {
            this._wrapperProductParameterValue = new WrapperProductParameterValue();
        }
        public string GetParameterValues()
        {
            var settings = new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.Objects, };
            string json = JsonConvert.SerializeObject(_wrapperProductParameterValue, settings);
            return json;
        }

        public void AddParameterValue(string json)
        {
            throw new NotImplementedException();
        }

        public void DeleteParameterValue(string json)
        {
            throw new NotImplementedException();
        }

        public void UpdateParameterValue(string json)
        {
            throw new NotImplementedException();
        }
    }
}
