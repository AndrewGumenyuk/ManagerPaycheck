using System;
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

namespace PurchaseProductService
{
    public class PurchaseProductRepositoryService : IPurchaseProductRepositoryService
    {
        private IPurchaseProductRepository _purchaseProductRepository;
        private WrapperPurchaseProduct _wrapper;

        public PurchaseProductRepositoryService()
        {
            IoCManagerCore.Start();
            _purchaseProductRepository = IoCManagerCore.Kernel.Get<IPurchaseProductRepository>();
            _wrapper = new WrapperPurchaseProduct();
        }
        public string GetAll()
        {
            var settings = new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.Objects};
            return JsonConvert.SerializeObject(_wrapper, settings);
        }

        public void Add(string json)
        {
            List<PurchaseProduct> pr = _wrapper.Deserialize(json);
            foreach (var it in pr)
            {
                _purchaseProductRepository.Add(it);
            }

            _purchaseProductRepository.Save();
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
