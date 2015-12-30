using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.CommunicationCommon.Abstract
{
    public interface IGeneralService<T> where T : class
    {
        //ObservableCollection<T> GetAll();
        string GetAll();

        void Add(string json);

        void Delete(string json);

        void Update(string json);
        string Serialize(object entity);
        ObservableCollection<T> Deserialize(string json);

    }
}
