using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace ProductParameterService
{
    public class ProductParameterRepositoryService : IProductParameterRepositoryService
    {
        private ProductParametrRepository _productParametrRepository;
        private ProductTypeRepository _productTypeRepository;
        private WrapperProductParameter wrapperProductParametr;
        private ProductParametrValueRepository _productParametrValueRepository;

        public ProductParameterRepositoryService()
        {
            _productParametrRepository = new ProductParametrRepository(new MngPaycheckContext());
            _productTypeRepository = new ProductTypeRepository(new MngPaycheckContext());
            _productParametrValueRepository = new ProductParametrValueRepository(new MngPaycheckContext());
            wrapperProductParametr = new WrapperProductParameter();
        }

        public string GetAll()
        {
            var settings = new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.Objects, };
            string json = JsonConvert.SerializeObject(wrapperProductParametr, settings);
            return json;
        }

        public void Add(string json)
        {
            ProductParametr pr = wrapperProductParametr.DeserializeProductParameter(json);
            foreach (var item in _productTypeRepository.GetAll())
            {
                if (item.Id == pr.ProductType.Id)
                {
                    pr.ProductType = null;
                    item.ProductParametrs.Add(pr);
                    _productTypeRepository.Save();
                }
            }
        }

        public void Delete(string json)
        {
            ProductParametr pr = wrapperProductParametr.DeserializeProductParameter(json);
            //If this parameter have a parametr we delete this parametr
            if (_productParametrValueRepository.GetAll().Where(a=>a.ProductParameterID == pr.Id).ToList().FirstOrDefault()!=null)
            {
                _productParametrValueRepository.Delete(
                       _productParametrValueRepository.GetAll()
                           .Where(prod => prod.ProductParameterID == prod.ProductParameterID)
                           .ToList()
                           .FirstOrDefault());
            }

           _productParametrValueRepository.Save();
            _productParametrRepository.Delete(_productParametrRepository.GetAll()
                .Where(param => param.Id == pr.Id)
                .ToList()
                .First());
            _productParametrRepository.Save();
        }

        public void Update(string json)
        {
            ProductParametr pr = wrapperProductParametr.DeserializeProductParameter(json);

            _productParametrRepository.Delete(_productParametrRepository.GetAll().Where(param => param.Id == pr.Id).ToList().First());
            _productParametrRepository.Save();

            foreach (var item in _productTypeRepository.GetAll().Where(item => item.Id == pr.ProductType.Id))
            {
                pr.ProductType = null;
                item.ProductParametrs.Add(pr);
                _productTypeRepository.Save();
            }
        }
    }
}
