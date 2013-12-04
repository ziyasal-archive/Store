using AutoMapper;

namespace Autofacture {
    public class OrderProfile : Profile {
        protected override void Configure() {
            Mapper.CreateMap<Order, OrderViewModel>();
        }
    }
}