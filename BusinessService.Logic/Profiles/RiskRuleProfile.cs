using AutoMapper;
using BusinessService.Contracts.Responses;
using BusinessService.Models;

namespace BusinessService.Logic.Profiles
{
    public class RiskRuleProfile : Profile
    {
        public RiskRuleProfile()
        {
            CreateMap<RiskRule, RiskRuleResponse>()
                .ForMember(dest => dest.Parameters, opt => opt.MapFrom(src => src.RiskRuleParameters));

            CreateMap<RiskRuleParameter, RiskRuleParameterResponse>();
        }
    }
}
