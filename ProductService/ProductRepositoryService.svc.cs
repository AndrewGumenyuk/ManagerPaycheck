﻿using System;
using System.Collections;
using System.Collections.Generic;
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
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace ProductService
{
    public class ProductRepositoryService : IProductRepositoryService
    {
        private IProductRepository _productRepository;
        public ProductRepositoryService()
        {
            _productRepository = new ProductRepository(new MngPaycheckContext());
        }

        WrapperProduct wrapperProduct = new WrapperProduct();
        public string GetAll()
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            
            string json = JsonConvert.SerializeObject(wrapperProduct, settings);

            return json;
        }

        public void Add(string json)
        {
            _productRepository.Add(wrapperProduct.DeserializeProduct(json));
            _productRepository.Save();
        }

        public void Delete(string json)
        {
            _productRepository.Delete(_productRepository.GetById(wrapperProduct.DeserializeProduct(json).Id));
            _productRepository.Save();
        }

        public void Update(string json)
        {
            _productRepository.Delete(_productRepository.GetById(wrapperProduct.DeserializeProduct(json).Id));
            _productRepository.Add(wrapperProduct.DeserializeProduct(json));
            _productRepository.Save();
        }
    }
}
