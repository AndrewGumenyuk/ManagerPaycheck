using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.IoCManager;
using Newtonsoft.Json;
using Ninject;

namespace ProductService
{
    public class ProductRepositoryService : IProductRepositoryService
    {
        private IProductRepository _productRepository;

        public ProductRepositoryService()
        {
            IoCManagerCore.Start();
            _productRepository = IoCManagerCore.Kernel.Get<IProductRepository>();
        }

        WrapperProduct wrapperProduct = new WrapperProduct();
        public string GetAll()
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            
            string json = JsonConvert.SerializeObject(wrapperProduct, settings);
            return json;
        }

        public void Add(string json)
        {
            _productRepository.Add(wrapperProduct.DeserializeProduct(json));
            _productRepository.Save();
        }

        public void Delete(string json)
        {
            _productRepository.Delete(_productRepository.GetById(wrapperProduct.DeserializeProduct(json).Id));
            _productRepository.Save();
        }

        public void Update(string json)
        {
            _productRepository.Delete(_productRepository.GetById(wrapperProduct.DeserializeProduct(json).Id));
            _productRepository.Add(wrapperProduct.DeserializeProduct(json));
            _productRepository.Save();
        }
    }
}
