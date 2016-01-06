using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.Entity;
using MngrPaycheck.IoCManager;
using Newtonsoft.Json;
using Ninject;

namespace BuyerService
{
    public class BuyerRepositoryService : IBuyerRepositoryService
    {
        private IBuyerRepository _buyerRepository;
        private IProductRepository _productRepository;
        private WrapperBuyer _wrapper;
        public BuyerRepositoryService()
        {
            IoCManagerCore.Start();
            _buyerRepository = IoCManagerCore.Kernel.Get<IBuyerRepository>();
            _productRepository = IoCManagerCore.Kernel.Get<IProductRepository>();
            _wrapper = new WrapperBuyer();
        }

        public string GetAll()
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            return JsonConvert.SerializeObject(_wrapper, settings);
        }

        public void Add(string json)
        {
            _buyerRepository.Add(_wrapper.Deserialize(json));
        }

        public void Delete(string json)
        {
            throw new NotImplementedException();
        }

        public void Update(string json)
        {
            throw new NotImplementedException();
        }
    }
}
