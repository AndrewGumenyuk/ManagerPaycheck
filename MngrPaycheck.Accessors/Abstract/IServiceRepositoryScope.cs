using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Accessors.Abstract
{
    public interface IServiceRepositoryScope : IDisposable
    {
        IBaseService CurrentService { get; set; }


        Tuple<IBaseAccessor, Type> GetCurrentAccessor { get; }
    }
}
