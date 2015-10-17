using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Logics.Strategy.Abstract;
using MngrPaycheck.Logics.Strategy.Concrete;

namespace MngrPaycheck.Logics
{
    public class LogicsType<T> where T : class
    {
        private BaseStrategy<T> _baseStrategy;

        public LogicsType(BaseStrategy<T> baseStrategy)
        {
            this._baseStrategy = baseStrategy;
        }
        
        public IEnumerable<T> Execute(object type)
        {
            return this._baseStrategy.GetElements(type);
        }
    }
}
