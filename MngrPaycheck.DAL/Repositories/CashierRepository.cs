using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;

namespace MngrPaycheck.DAL.Repositories
{
    public class CashierRepository: GenericRepository<Cashier>, ICashierRepository
    {
        public CashierRepository(IMngPaycheckContext context) : base(context)
        {
        }
    }
}
