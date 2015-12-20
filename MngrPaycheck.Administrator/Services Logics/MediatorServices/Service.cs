using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MngrPaycheck.Administrator.Services_Logics
{
    public abstract class Service
    {
        protected ServiceMediator _serviceMediator;

        public Service(ServiceMediator serviceMediator)
        {
            this._serviceMediator = serviceMediator;
        }

        //public abstract ObservableCollection<object> GetAll();

        public virtual void Add(string json)
        {
            _serviceMediator.Add(json, this);
        }

        public virtual void Delete(string json)
        {
            _serviceMediator.Delete(json, this);
        }

        public virtual void Update(string json)
        {
            _serviceMediator.Update(json, this);
        }

        public virtual string Serialize(object entity)
        {
            return _serviceMediator.Serialize(entity, this);
        }
    }
}
