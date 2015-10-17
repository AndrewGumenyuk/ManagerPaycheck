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
    public class ProductTypeRepository: GenericRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(IMngPaycheckContext context) : base(context)
        {
        }
    }
}
