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
    public class ProductParametrValueRepository: GenericRepository<ProductParametrValue>, IProductParametrValueRepository
    {
        public ProductParametrValueRepository(IMngPaycheckContext context) : base(context)
        {
        }
    }
}
