using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Administrator.ProductParametrServiceRef;
using MngrPaycheck.Administrator.Services_Logics.Wrapper;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace MngrPaycheck.Administrator.Services_Logics
{
    public class ProductParametrServiceLogics : Service
    {
        private ProductParameterRepositoryServiceClient serviceProductParametClient ;
        private WrapperProductParametr obj;
        public ProductParametrServiceLogics(ServiceMediator mediator)
            : base(mediator)
        {
            this.serviceProductParametClient = new ProductParameterRepositoryServiceClient();
            obj = JsonConvert.DeserializeObject<WrapperProductParametr>(serviceProductParametClient.GetProductParameters());
        }

        public ObservableCollection<ProductParametr> Products()
        {
            return obj.CollectionProductParametrs;
        }

        public override void Add(string json)
        {
            serviceProductParametClient.AddProductParameter(json);
        }

        public override void Delete(string json)
        {
            serviceProductParametClient.DeleteProductParameter(json);
        }

        public override void Update(string json)
        {
            serviceProductParametClient.UpdateProductParameter(json);
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
