using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace ProductService
{
    public class ProductRepositoryService : IProductRepositoryService
    {
        private ProductRepository _productRepository = new ProductRepository(MngPaycheckContext.Instance);
        WrapperProduct wrapperProduct = new WrapperProduct();
        public string GetProducts()
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            
            string json = JsonConvert.SerializeObject(wrapperProduct, settings);

            return json;
        }

        public void AddProduct(string json)
        {
            _productRepository.Add(wrapperProduct.DeserializeProduct(json));
            _productRepository.Save();
        }

        public void DeleteProduct(string json)
        {
            _productRepository.Delete(_productRepository.GetById(wrapperProduct.DeserializeProduct(json).Id));
            _productRepository.Save();
        }

        public void UpdateProducts(string json)
        {
            _productRepository.Delete(_productRepository.GetById(wrapperProduct.DeserializeProduct(json).Id));
            _productRepository.Add(wrapperProduct.DeserializeProduct(json));
            _productRepository.Save();
        }
    }
}
