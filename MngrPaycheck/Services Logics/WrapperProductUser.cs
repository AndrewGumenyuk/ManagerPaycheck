using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Services_Logics
{
   public class WrapperProductUser
    {
         public List<Product> CollectionProducts { get; set; }
         public WrapperProductUser()
        {
            this.CollectionProducts = new List<Product>();
        }
    }
}
