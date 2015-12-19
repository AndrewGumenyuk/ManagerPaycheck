using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MngrPaycheck.Accessors.Abstract
{
    public interface IBaseService
    {
        void AddItem(JToken item);

        //add
        //delete
        void DeleteItem(JToken item);

        //getAll
        List<JToken> GetAll();
    }
}
