using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.Entity;
using MngrPaycheck.Logics.Strategy.Abstract;

namespace MngrPaycheck.Logics.Strategy.Concrete
{
    public class PaymentTypeStrategy : BaseStrategy<Purchase>
    {
        private readonly IPurchaseRepository _purchaseRepository = new PurchaseRepository(new MngPaycheckContext());
        public override IEnumerable<Purchase> GetElements(object TypePayment)
        {
            return
                _purchaseRepository.GetAll().Where(a => a.PaymentType.Name == ((PaymentType) TypePayment).Name).ToList();
        }
    }
}
