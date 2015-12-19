using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Accessors.Abstract;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Accessors.Concrate.Accessors
{
    public class ProductAccessor : IProductServiceAccessor
    {
        public Product GetEntity(Newtonsoft.Json.Linq.JToken value)
        {
            throw new NotImplementedException();
        }
    }
}
