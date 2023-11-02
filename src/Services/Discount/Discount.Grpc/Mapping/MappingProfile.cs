using AutoMapper;
using Discount.Grpc.Data.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapping
{
    public class MappingProfile : Profile // from automapper
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
