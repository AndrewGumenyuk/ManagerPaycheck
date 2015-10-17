using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Common.DAL.Infrastructure
{
    public interface IMngPaycheckContext: IDisposable
    {
        IDbSet<Cashier> Cashiers { get; set; }
        IDbSet<PaymentType> PaymentTypes { get; set; }
        IDbSet<Product> Products { get; set; }
        IDbSet<ProductParametr> ProductParametrs { get; set; }
        IDbSet<ProductParametrValue> ProductParametrValues { get; set; }
        IDbSet<ProductType> ProductTypes { get; set; }
        IDbSet<Purchase> Purchases { get; set; }
        IDbSet<Supermarket> Supermarkets { get; set; }
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;      // It's done, because native implementation returns DbSet
        int SaveChanges();
    }
}
