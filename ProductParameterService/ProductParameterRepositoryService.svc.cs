using System.Linq;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.Entity;
using MngrPaycheck.IoCManager;
using Newtonsoft.Json;
using Ninject;

namespace ProductParameterService
{
    public class ProductParameterRepositoryService : IProductParameterRepositoryService
    {
        private IProductParametrRepository _productParametrRepository;
        private IProductTypeRepository _productTypeRepository;
        private IProductParametrValueRepository _productParametrValueRepository;
        private WrapperProductParameter wrapperProductParametr;

        public ProductParameterRepositoryService()
        {
            IoCManagerCore.Start();
            _productTypeRepository = IoCManagerCore.Kernel.Get<IProductTypeRepository>();
            _productParametrRepository = IoCManagerCore.Kernel.Get<IProductParametrRepository>();
            _productParametrValueRepository = IoCManagerCore.Kernel.Get<IProductParametrValueRepository>();
            wrapperProductParametr = new WrapperProductParameter();
        }

        public string GetAll()
        {
            var settings = new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.Objects, };
            string json = JsonConvert.SerializeObject(wrapperProductParametr, settings);
            return json;
        }

        public void Add(string json)
        {
            ProductParametr pr = wrapperProductParametr.DeserializeProductParameter(json);
            foreach (var item in _productTypeRepository.GetAll())
            {
                if (item.Id == pr.ProductType.Id)
                {
                    pr.ProductType = null;
                    item.ProductParametrs.Add(pr);
                    _productTypeRepository.Save();
                }
            }
        }

        public void Delete(string json)
        {
            ProductParametr pr = wrapperProductParametr.DeserializeProductParameter(json);
            //If this parameter have a parametr we delete this parametr
            if (_productParametrValueRepository.GetAll().Where(a => a.ProductParameterID == pr.Id).ToList().FirstOrDefault() != null)
            {
                _productParametrValueRepository.Delete(
                       _productParametrValueRepository.GetAll()
                           .Where(prod => prod.ProductParameterID == prod.ProductParameterID)
                           .ToList()
                           .FirstOrDefault());
            }

           _productParametrValueRepository.Save();
            _productParametrRepository.Delete(_productParametrRepository.GetAll()
                .Where(param => param.Id == pr.Id)
                .ToList()
                .First());
            _productParametrRepository.Save();
        }

        public void Update(string json)
        {
            ProductParametr pr = wrapperProductParametr.DeserializeProductParameter(json);

            _productParametrRepository.Delete(_productParametrRepository.GetAll().Where(param => param.Id == pr.Id).ToList().First());
            _productParametrRepository.Save();

            foreach (var item in _productTypeRepository.GetAll().Where(item => item.Id == pr.ProductType.Id))
            {
                pr.ProductType = null;
                item.ProductParametrs.Add(pr);
                _productTypeRepository.Save();
            }
        }
    }
}
