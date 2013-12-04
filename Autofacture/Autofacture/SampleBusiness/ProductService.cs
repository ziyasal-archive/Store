using Autofacture.SampleBusiness.Domain;
using Autofacture.SampleBusiness.ViewModel;
using AutoMapper;
using Ploeh.AutoFixture;

namespace Autofacture.SampleBusiness {
    public class ProductService:IProductService {
        private readonly IMappingEngine _mappingEngine;

        public ProductService(IMappingEngine mappingEngine) {
            _mappingEngine = mappingEngine;
        }

        public ProductViewModel GetProduct() {
            IFixture fixture = new Fixture();
            return _mappingEngine.Map<Product, ProductViewModel>(fixture.Create<Product>());
        }
    }
}