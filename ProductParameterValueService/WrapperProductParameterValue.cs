using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace ProductParameterValueService
{
    public class WrapperProductParameterValue
    {
        public List<ProductParametrValue> CollectionProductTypes { get; set; }

        private ProductParametrValueRepository _productParameterValuesRepository;

        public WrapperProductParameterValue()
        {
            _productParameterValuesRepository = new ProductParametrValueRepository(MngPaycheckContext.Instance);
            CollectionProductTypes = (List<ProductParametrValue>)_productParameterValuesRepository.GetAll();
        }

        public ProductParametrValue DeserializeProductParameterValue(string json)
        {
            return JsonConvert.DeserializeObject<ProductParametrValue>(json);
        }
    }
}
