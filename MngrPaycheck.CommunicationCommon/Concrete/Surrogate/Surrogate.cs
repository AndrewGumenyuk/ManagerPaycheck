using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.CommunicationCommon.Abstract;
using Newtonsoft.Json;

namespace MngrPaycheck.CommunicationCommon.Concrete
{
    public class Surrogate<T> : IGeneralService<T> where T : class
    {
        private IGeneralService<T> _operator;

        public Surrogate(IGeneralService<T> Operator)
        {
            this._operator = Operator;
        }

        public string GetAll()
        {
            return _operator.GetAll();
        }

        public void Add(string json)
        {
            _operator.Add(json);
        }

        public void Delete(string json)
        {
            _operator.Delete(json);
        }

        public void Update(string json)
        {
            _operator.Update(json);
        }

        public string Serialize(object entity)
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            return JsonConvert.SerializeObject(entity, settings);
        }

        public ObservableCollection<T> Deserialize(string json)
        {
            return _operator.Deserialize(json);
        }
    }
}
