using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace ProductTypeService
{    public class ProductTypeRepositoryService : IProductTypeRepositoryService
    {
        private ProductTypeRepository _productTypeRepository = new ProductTypeRepository(MngPaycheckContext.Instance);
        private ProductRepository _productRepository = new ProductRepository(MngPaycheckContext.Instance);

        WrapperProductType wrapperTypeProduct = new WrapperProductType();

        public string GetProductTypes()
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
        public void AddProductType(string json)
        {
            ProductType productType = wrapperTypeProduct.DeserializeProduct(json);
            ICollection<Product> prTypesProduct = productType.Products;// because productType`ve child elements
            productType.Products = null;// after that productType don`t have child elements and we can this add to db

            foreach (var item in _productTypeRepository.GetAll())
            {
                ////if we have productType with the same name we give product id type that was
                if (item.Name == productType.Name)  // will replace by sql script
                {
                    foreach (var prTP in prTypesProduct)
                    {
                        prTP.ProductType = item;
                        prTP.ProductTypeID = item.Id;
                        ReplacementProduct(prTP);
                    }
                }
                else
                {
                    ReplacementProducts(prTypesProduct);
                }
            }

            DeleteEmptyProductType();
            _productTypeRepository.Save();
            _productRepository.Save();
        }

        public void ReplacementProduct(Product ProductClient)
        {
            _productRepository.Delete(_productRepository.GetById(ProductClient.Id));
            _productRepository.Add(ProductClient);
        }

        public void ReplacementProducts(ICollection<Product> ProductsClient)
        {
            foreach (var item in ProductsClient)
            {
                _productRepository.Delete(_productRepository.GetById(item.Id));
                _productRepository.Add(item);
            }
        }

        public void DeleteProductType(string json)
        {
            ProductType productType = wrapperTypeProduct.DeserializeProduct(json);
           _productRepository.GetAll().Where(prod => prod.ProductType.Id == productType.Id)
               .Single().ProductType=null;

            DeleteEmptyProductType();
            _productTypeRepository.Save();
        }

        public void UpdateProductTypes(string json)
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
