using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Accessors.Abstract;
using MngrPaycheck.Accessors.Concrate.Accessors;
using MngrPaycheck.Administrator.ProductParametrServiceRef;

namespace MngrPaycheck.Accessors.Concrate
{
    class AccessorFactory : IAccsessorFactory
    {
        public Tuple<IBaseAccessor, Type> GetAcssesor(IBaseService service)
        {

            if (typeof (IProductParameterRepositoryService) == service.GetType())
            {
                ProductAccessor accessor = new ProductAccessor();
                return new Tuple<IBaseAccessor, Type>(accessor, accessor.GetType());
            }
        

                else 
                    throw  new NotImplementedException();
        }
    }
}
