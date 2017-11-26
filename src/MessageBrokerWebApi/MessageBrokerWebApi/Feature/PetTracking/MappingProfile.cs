using AutoMapper;
using ENSE483Group3Fall2017.PetTracking.Contracts.V1;

namespace ENSE483Group3Fall2017.MessageBrokerWebApi.Feature.PetTracking
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Create.Command.TrackingItem, TrackingItem>();
            CreateMap<Create.Command, TrackingBatch>()
                .ForMember(dst => dst.Items, opt => opt.MapFrom(src => src.TrackingItems));
        }
    }
}
