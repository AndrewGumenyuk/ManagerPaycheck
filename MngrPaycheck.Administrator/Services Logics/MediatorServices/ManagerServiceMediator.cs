using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Administrator.Services_Logics
{
    public class ManagerServiceMediator: ServiceMediator
    {
        public Service ProductType { get; set; }
        public Service Product { get; set; }
        public Service ProductParametr { get; set; }
        public Service ProductParametrValue { get; set; }

        public override void Update(string msg, Service service)
        {
            if (ProductType == service) { ProductType.Update(msg); }
            else if (Product == service) { Product.Update(msg); }
            else if (ProductParametr == service) { ProductParametr.Update(msg); }
            else if (ProductParametrValue == service) { ProductParametrValue.Update(msg); }

        }

        public override void Add(string msg, Service service)
        {
            if  (this.ProductType == service)   { this.ProductType.Add(msg); }
            else if (this.Product == service)    { this.Product.Add(msg); }
            else if (this.ProductParametr == service) { this.ProductParametr.Add(msg); }
            else if (this.ProductParametrValue == service) { this.ProductParametrValue.Add(msg); }
        }

        public override string Serialize(object obj, Service service)
        {
            string str = null;
            if (this.ProductType == service) { str = this.ProductType.Serialize(obj); }
            else if (this.Product == service) { str = this.Product.Serialize(obj); }
            else if (this.ProductParametr == service) { str = this.ProductParametr.Serialize(obj); }
            else if (this.ProductParametrValue == service) { str = this.ProductParametrValue.Serialize(obj); }
            return str;
        }

        public override void Delete(string msg, Service service)
        {
            if (this.ProductType == service) { this.ProductType.Delete(msg); }
            else if (this.Product == service) { this.Product.Delete(msg); }
            else if (this.ProductParametr == service) { this.ProductParametr.Delete(msg); }
            else if (this.ProductParametrValue == service) { this.ProductParametrValue.Delete(msg); }
        }
    }
}
