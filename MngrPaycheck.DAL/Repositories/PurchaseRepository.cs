using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;

namespace MngrPaycheck.DAL.Repositories
{
    public class PurchaseRepository: GenericRepository<Purchase>, IPurchaseRepository, ICloneable
    {
        public PurchaseRepository(IMngPaycheckContext context) : base(context)
        {
        }

        public object Clone()
        {
            var clone = new PurchaseRepository(MngPaycheckContext.Instance.ShallowCopy());
            return clone;
        }
    }
}
