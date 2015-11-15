using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    [DataContract(IsReference = true)]
    public class Purchase
    {
        public Purchase()
        {
            this.Id = Guid.NewGuid();
            this.Products = new HashSet<Product>();
        }
        
        [Required] [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public float SumPurchase { get; set; }

        [DataMember]
        public DateTime PurchaseDate { get; set; }

        [DataMember]
        public string PurchaseAdress { get; set; }

        [DataMember]
        public bool Favorite { get; set; }

        [DataMember]
        public Guid? SupermarketID { get; set; }

        [DataMember]
        public Guid PaymentTypeID { get; set; }


        #region properties
        [DataMember]
        public virtual PaymentType PaymentType { get; set; }

        [DataMember]
        public virtual Supermarket Supermarket { get; set; }

        [DataMember]
        public virtual ICollection<Product> Products { get; set; } 
        #endregion
    }
}
