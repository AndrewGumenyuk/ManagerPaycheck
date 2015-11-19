using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Administrator.Services_Logics
{
   public class WrapperProductAdministrator
    {
          public List<Product> CollectionProducts { get; set; }
       public WrapperProductAdministrator()
        {
            this.CollectionProducts = new List<Product>();
        }
    }
}
