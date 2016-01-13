using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.IoCManager;
using Newtonsoft.Json;
using Ninject;

namespace PurchaseService
{
    public class PurchaseRepositoryService : IPurchaseRepositoryService
    {
        private IPurchaseRepository _purchaseRepository;
        private WrapperPurchase _wrapper;
        public PurchaseRepositoryService()
        {
            IoCManagerCore.Start();
            _purchaseRepository = IoCManagerCore.Kernel.Get<IPurchaseRepository>();
            _wrapper = new WrapperPurchase();
        }

        public string GetAll()
        {
            var settings = new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.Objects};
            string json = JsonConvert.SerializeObject(_wrapper, settings);
            return json;
        }

        public void Add(string json)
        {
            _purchaseRepository.Add(_wrapper.DeserializePurchase(json));
            _purchaseRepository.Save();
        }

        public void Delete(string json)
        {
            throw new NotImplementedException();
        }

        public void Update(string json)//Purchases in supermarket never don't be delete, so in method update we use only change favourite
        {
            _purchaseRepository.GetAll()
                .Where(purch => purch.Id == _wrapper.DeserializePurchase(json).Id)
                .Single()
                .Favorite = _wrapper.DeserializePurchase(json).Favorite;
            _purchaseRepository.Save();
        }
    }
}
