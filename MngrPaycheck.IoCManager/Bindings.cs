using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.DAL.Repositories.Abstract;
using Ninject.Modules;

namespace MngrPaycheck.IoCManager
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IProductTypeRepository>().To<ProductTypeRepository>();
            Bind<IProductParametrRepository>().To<ProductParametrRepository>();
            Bind<IProductParametrValueRepository>().To<ProductParametrValueRepository>();
            Bind<IPaymentTypeRepository>().To<PaymentTypeRepository>();
            Bind<IPurchaseProductRepository>().To<PurchaseProductRepository>();
            Bind<IPurchaseRepository>().To<PurchaseRepository>();
            Bind<ICashierRepository>().To<CashierRepository>();
            Bind<IBuyerRepository>().To<BuyerRepository>();

            Bind<IMngPaycheckContext>().To<MngPaycheckContext>();
        }
    }
}
