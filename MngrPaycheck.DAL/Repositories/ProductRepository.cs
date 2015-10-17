using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.Entity;

namespace MngrPaycheck.DAL.Repositories.Abstract
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IMngPaycheckContext context) : base(context)
        {
        }
    }
}
