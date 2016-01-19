using System.Collections.Generic;
using System.Linq;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.Entity;
using MngrPaycheck.IoCManager;
using Newtonsoft.Json;
using Ninject;

namespace ProductTypeService
{    
    public class ProductTypeRepositoryService : IProductTypeRepositoryService
    {
        private IProductTypeRepository _productTypeRepository;
        private IProductRepository _productRepository;
        private WrapperProductType wrapperTypeProduct;

        public ProductTypeRepositoryService()
        {
             IoCManagerCore.Start();
             wrapperTypeProduct = new WrapperProductType();           
            _productRepository = IoCManagerCore.Kernel.Get<IProductRepository>();
            _productTypeRepository = IoCManagerCore.Kernel.Get<IProductTypeRepository>();
        }

        public string GetAll()
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            string json = JsonConvert.SerializeObject(wrapperTypeProduct, settings);
            return json;
        }

        /// <summary>
        /// In this method i can add product type to product
        /// </summary>
        /// <param name="json"></param>
        public void Add(string json)
        {
            ProductType productType = wrapperTypeProduct.DeserializeProduct(json);
            ICollection<Product> prTypesProduct = productType.Products;// because productType`ve child elements
            productType.Products = null;// after that productType don`t have child elements and we can this add to db
            bool includeType = false;
            Product dynamicProduct = new Product();

            foreach (var item in _productTypeRepository.GetAll())
            {
                ////if we have productType with the same name we give product id type that was
                if (item.Name == productType.Name)  // will replace by sql script
                {
                    foreach (var prTP in prTypesProduct)
                    {
                        ReplacementProduct(prTP);
                        dynamicProduct = prTP;
                        dynamicProduct.ProductType = null;
                        dynamicProduct.ProductTypeID = item.Id;
                    }
                    includeType = true;
                    _productRepository.Add(dynamicProduct);
                }
            }

            if (!includeType)
            {
                ReplacementProducts(prTypesProduct);
            }
            _productRepository.Save();
        }

        public void ReplacementProduct(Product ProductClient)
        {
            _productRepository.Delete(_productRepository.GetAll().Where(pr => pr.Name == ProductClient.Name).ToList().FirstOrDefault());
            _productRepository.Save();
        }

        public void ReplacementProducts(ICollection<Product> ProductsClient)
        {
            foreach (var item in ProductsClient)
            {
                _productRepository.Delete(_productRepository.GetById(item.Id));
                _productRepository.Add(item);
            }
        }

        public void Delete(string json)
        {
            ProductType productType = wrapperTypeProduct.DeserializeProduct(json);
           foreach (var item in _productRepository.GetAll().Where(item => item.ProductTypeID == productType.Id))
           {
               _productRepository.Delete(item);
               _productRepository.Save();

               item.ProductType = null;
               _productRepository.Add(item);
           }
            _productRepository.Save();
            _productTypeRepository.Save();
        }
        public void Update(string json)
        {
            ProductType prType = wrapperTypeProduct.DeserializeProduct(json);

            _productTypeRepository.GetAll()
                .Where(it => it.Id == prType.Id)
                .Single().Name = prType.Name;

            DeleteEmptyProductType();
            _productTypeRepository.Save();
        }

        /// <summary>
        /// when changed that product don't have type and 
        /// after thar type don't have products we delete this type
        /// </summary>
        public void DeleteEmptyProductType()
        {
            foreach (var item in _productTypeRepository.GetAll())
            {
                if (item.Products == null)
                {
                    _productTypeRepository.Delete(item);
                }
            }
        }
    }
}
