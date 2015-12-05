using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace ProductTypeService
{
    public class WrapperProductType
    {
       public List<ProductType> CollectionProductTypes { get; set; }

        private ProductTypeRepository _productTypeRepository;

        public WrapperProductType()
        {
            _productTypeRepository = new ProductTypeRepository(MngPaycheckContext.Instance);
            CollectionProductTypes = (List<ProductType>)_productTypeRepository.GetAll();
        }

        public ProductType DeserializeProduct(string json)
        {
            return JsonConvert.DeserializeObject<ProductType>(json);
        }
    }
}
