using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Mvc;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.Entity;
using MngrPaycheck.IoCManager;
using Newtonsoft.Json;
using Ninject;
using ProductParameterValueService;

namespace ProductParameterValueService
{
    public class ProductParameterValueRepositoryService : IProductParameterValueRepositoryService
    {
        private WrapperProductParameterValue _wrapperProductParameterValue;
        private IProductParametrValueRepository _productParameterValueRepository;

        public ProductParameterValueRepositoryService()
        {
            IoCManagerCore.Start();
            _productParameterValueRepository = IoCManagerCore.Kernel.Get<IProductParametrValueRepository>();

            _wrapperProductParameterValue = new WrapperProductParameterValue();
        }
        public string GetAll()
        {
            var settings = new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.Objects, };
            string json = JsonConvert.SerializeObject(_wrapperProductParameterValue, settings);
            return json;
        }

        public void Add(string json)
        {
            ProductParametrValue pr = _wrapperProductParameterValue.DeserializeProductParameterValue(json);
            pr.Product = null;
            pr.ProductParametr = null;
            _productParameterValueRepository.Add(pr);
            _productParameterValueRepository.Save();
        }

        public void Delete(string json)
        {
            ProductParametrValue pr = _wrapperProductParameterValue.DeserializeProductParameterValue(json);
            _productParameterValueRepository.Delete(
                _productParameterValueRepository.GetAll()
                    .Where(prm => prm.ProductParameterID == pr.ProductParameterID)
                    .ToList()
                    .FirstOrDefault());
            _productParameterValueRepository.Save();
        }

        public void Update(string json)
        {
            Delete(json);
            Add(json);
        }
    }
}
