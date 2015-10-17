using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    public class Purchase
    {
        public Purchase()
        {
            this.Id = Guid.NewGuid();
            this.Products = new HashSet<Product>();
        }
        
        [Required] [Key]
        public Guid Id { get; private set; }

        public float SumPurchase { get; set; }

        public DateTime PurchaseDate { get; set; }
        
        public string PurchaseAdress { get; set; }

        public bool Favorite { get; set; }

        public Guid? SupermarketID { get; set; }
        public Guid PaymentTypeID { get; set; }


        #region properties
        public virtual PaymentType PaymentType { get; set; }
        public virtual Supermarket Supermarket { get; set; }
        public virtual ICollection<Product> Products { get; set; } 
        #endregion
    }
}
