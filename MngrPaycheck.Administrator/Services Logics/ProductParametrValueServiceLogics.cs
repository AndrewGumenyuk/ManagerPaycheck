using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Administrator.ProductParameterValueServiceRef;
using MngrPaycheck.Administrator.Services_Logics.Wrapper;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace MngrPaycheck.Administrator.Services_Logics
{
    public class ProductParametrValueServiceLogics : Service
    {
        private ProductParameterValueRepositoryClient _service1Client;
        private WrapperProductParameterValue obj;

        public ProductParametrValueServiceLogics(ServiceMediator serviceMediator) : base(serviceMediator)
        {
            this._service1Client = new ProductParameterValueRepositoryClient();
            obj = JsonConvert.DeserializeObject<WrapperProductParameterValue>(_service1Client.GetParameterValues());
        }

        public ObservableCollection<ProductParametrValue> Products()
        {
            return obj.CollectionProductParametrValues;
        }

        public override void Add(string json)
        {
            _service1Client.AddParameterValue(json);
        }

        public override void Delete(string json)
        {
            _service1Client.DeleteParameterValue(json);
        }

        public override void Update(string json)
        {
            _service1Client.UpdateParameterValue(json);
        }

        public override string Serialize(object entity)
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            return JsonConvert.SerializeObject(entity, settings);
        }
    }
}
