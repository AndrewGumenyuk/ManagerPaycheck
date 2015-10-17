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
    public class ProductParametrRepository: GenericRepository<ProductParametr>, IProductParametrRepository
    {
        public ProductParametrRepository(IMngPaycheckContext context) : base(context)
        {
        }
    }
}
