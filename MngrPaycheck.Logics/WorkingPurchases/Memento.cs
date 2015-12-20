using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Logics.WorkingPurchases
{
    public class Memento
    {
        private List<Purchase> _stateList = new List<Purchase>();
        private PurchaseRepository _state;

        public Memento(PurchaseRepository purchaseRepository)
        {
            this._state = (PurchaseRepository)purchaseRepository.Clone();
            var listFromRepo = purchaseRepository.GetAll();
            foreach (var p in listFromRepo)
            {
                _stateList.Add(p.DeepCopy());
            }
        }

        public List<Purchase> StateList
        {
            get { return _stateList;}
        } 

        public PurchaseRepository State
        {
            get { return _state; }
        }
    }
}
