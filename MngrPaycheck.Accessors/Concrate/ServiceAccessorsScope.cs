using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Accessors.Abstract;

namespace MngrPaycheck.Accessors.Concrate
{
    public class ServiceAccessorsScope : IServiceRepositoryScope // буду дергать этот класс
    {
        //TODO : remove IBaseService and Services Interfaces Into abstract servcie class library
        private IBaseService _service;
        private IAccsessorFactory _factory;
        public IBaseService CurrentService
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ServiceAccessorsScope(IBaseService service)
        {
            _service = service;
            _factory = new AccessorFactory();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public  Tuple<IBaseAccessor, Type> GetCurrentAccessor
        {
            get { return _factory.GetAcssesor(_service); }
        }
    }
}
