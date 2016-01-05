using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.Entity;

namespace MngrPaycheck.DAL.Repositories
{
    public class BuyerRepository : GenericRepository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(IMngPaycheckContext context) : base(context)
        {
        }
    }
}
