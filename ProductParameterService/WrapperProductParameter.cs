using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace ProductParameterService
{
    class WrapperProductParameter
    {
        public List<ProductParametr> CollectionProductTypes { get; set; }

        private ProductParametrRepository _productParametersRepository;

        public WrapperProductParameter()
        {
            _productParametersRepository = new ProductParametrRepository(MngPaycheckContext.Instance);
            CollectionProductTypes = (List<ProductParametr>)_productParametersRepository.GetAll();
        }

        public ProductParametr DeserializeProductParameter(string json)
        {
            return JsonConvert.DeserializeObject<ProductParametr>(json);
        }
    }
}
