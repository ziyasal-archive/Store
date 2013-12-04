using Autofacture.SampleBusiness.ViewModel;

namespace Autofacture.SampleBusiness {
    internal interface IProductService {
        ProductViewModel GetProduct();
    }
}