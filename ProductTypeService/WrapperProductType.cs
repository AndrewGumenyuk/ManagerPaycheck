using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;
using MngrPaycheck.IoCManager;
using Newtonsoft.Json;
using Ninject;

namespace ProductTypeService
{
    public class WrapperProductType
    {
       public List<ProductType> CollectionProductTypes { get; set; }

        private ProductTypeRepository _productTypeRepository;

        public WrapperProductType()
        {
            IoCManagerCore.Start();
            _productTypeRepository = (ProductTypeRepository) IoCManagerCore.Kernel.Get<IProductTypeRepository>();
            CollectionProductTypes = (List<ProductType>)_productTypeRepository.GetAll();
        }

        public ProductType DeserializeProduct(string json)
        {
            return JsonConvert.DeserializeObject<ProductType>(json);
        }
    }
}
