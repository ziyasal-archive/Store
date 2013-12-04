using Autofacture.SampleBusiness.Domain;
using Autofacture.SampleBusiness.ViewModel;
using AutoMapper;

namespace Autofacture.SampleBusiness.MappingProfiles {
    public class ProductMapperProfile : Profile {
        protected override void Configure() {
            Mapper.CreateMap<Product, ProductViewModel>();
        }
    }
}