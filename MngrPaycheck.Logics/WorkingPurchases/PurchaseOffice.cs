using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Logics.WorkingPurchases
{
    public class PurchaseOffice
    {
        private PurchaseRepository _purchaseRepository;

        public PurchaseOffice()
        {
            _purchaseRepository = new PurchaseRepository(MngPaycheckContext.Instance);
        }

        public PurchaseRepository State
        {
            get { return _purchaseRepository; }
            set
            {
                _purchaseRepository = value;
                Console.WriteLine("STATE !!!");
                foreach (var item in _purchaseRepository.GetAll())
                {
                    Console.WriteLine(item.Favorite);
                }
            }
        }

        public Memento CreateMemento()
        {
            return (new Memento((PurchaseRepository)_purchaseRepository.Clone()));
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("restoring....");
            State = memento.State;
            foreach (var pur in memento.StateList)
            {
                State.Update(pur);//.переписать апдейт
            }
        }
    }
}

