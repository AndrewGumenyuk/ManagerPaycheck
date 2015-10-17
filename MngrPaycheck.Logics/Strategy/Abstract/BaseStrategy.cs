using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;

namespace MngrPaycheck.Logics.Strategy.Abstract
{
    public abstract class BaseStrategy<T> where T: class //Я передаю тип, а получаю список продуктов
    {
        public abstract IEnumerable<T> GetElements(object a);
    }
}
