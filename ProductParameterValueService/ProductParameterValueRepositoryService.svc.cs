﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.Entity;
using Newtonsoft.Json;
using ProductParameterValueService;

namespace ProductParameterValueService
{
    public class ProductParameterValueRepositoryService : IProductParameterValueRepositoryService
    {
        private WrapperProductParameterValue _wrapperProductParameterValue;
        private IProductParametrValueRepository _productParameterValueRepository;

        public ProductParameterValueRepositoryService()
        {
            _wrapperProductParameterValue = new WrapperProductParameterValue();
            _productParameterValueRepository = new ProductParametrValueRepository(new MngPaycheckContext());
        }
        public string GetParameterValues()
        {
            var settings = new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.Objects, };
            string json = JsonConvert.SerializeObject(_wrapperProductParameterValue, settings);
            return json;
        }

        public void AddParameterValue(string json)
        {
            ProductParametrValue pr = _wrapperProductParameterValue.DeserializeProductParameterValue(json);
            pr.Product = null;
            pr.ProductParametr = null;
            _productParameterValueRepository.Add(pr);
            _productParameterValueRepository.Save();
        }

        public void DeleteParameterValue(string json)
        {
            ProductParametrValue pr = _wrapperProductParameterValue.DeserializeProductParameterValue(json);
            _productParameterValueRepository.Delete(
                _productParameterValueRepository.GetAll()
                    .Where(prm => prm.ProductParameterID == pr.ProductParameterID)
                    .ToList()
                    .FirstOrDefault());
            _productParameterValueRepository.Save();
        }

        public void UpdateParameterValue(string json)
        {
            DeleteParameterValue(json);
            AddParameterValue(json);
        }
    }
}