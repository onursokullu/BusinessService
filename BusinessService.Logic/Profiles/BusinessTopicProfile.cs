using AutoMapper;
using BusinessService.Contracts.Responses;
using BusinessService.Models;

namespace BusinessService.Logic.Profiles
{
    public class BusinessTopicProfile : Profile
    {
        public BusinessTopicProfile()
        {
            CreateMap<BusinessTopic, GetBusinessTopicResponse>()
                .ForMember(dest => dest.PartnerName, opt => opt.MapFrom(src => src!.Partner!.Name));
        }
    }
}
