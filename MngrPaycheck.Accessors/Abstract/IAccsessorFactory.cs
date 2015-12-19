using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Accessors.Abstract
{
    public interface IAccsessorFactory
    {
        Tuple<IBaseAccessor, Type> GetAcssesor(IBaseService service);
    }
}
