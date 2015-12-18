using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.Entity;

namespace MngrPaycheck.DAL.Context
{
    public class MngPaycheckContext: DbContext, IMngPaycheckContext, IDisposable
    {
        public MngPaycheckContext()
            : base("MngrPaycheckTestFillTestDB50"){}

        public static readonly Lazy<MngPaycheckContext> _instance = new Lazy<MngPaycheckContext>(() => new MngPaycheckContext());

        public IDbSet<Cashier> Cashiers { get; set; }
        public IDbSet<PaymentType> PaymentTypes { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductParametr> ProductParametrs { get; set; }
        public IDbSet<ProductParametrValue> ProductParametrValues { get; set; }
        public IDbSet<ProductType> ProductTypes { get; set; }
        public IDbSet<Purchase> Purchases { get; set; }
        public IDbSet<Supermarket> Supermarkets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public static MngPaycheckContext Instance
        {
            get { return _instance.Value; }
        }
    }
}
