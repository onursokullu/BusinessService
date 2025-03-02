using AutoMapper;
using BusinessService.Contracts.Requests;
using BusinessService.Contracts.Responses;
using BusinessService.Models;

namespace BusinessService.Logic.Profiles
{
    public class RiskAnalysisProfile : Profile
    {
        public RiskAnalysisProfile()
        {
            CreateMap<RiskAnalysis, RiskAnalysisListResponse>();

            CreateMap<CreateRiskAnalysisRequest, RiskAnalysis>()
            .ForMember(dest => dest.Id, opt => Guid.NewGuid())
            .ForMember(dest => dest.BusinessTopicId, opt => opt.MapFrom(src => src.BusinessTopicId))
            .ForMember(dest => dest.RiskScore, opt => opt.MapFrom(src => src.RiskParameters.Values.Sum())) // Example calculation
            .ForMember(dest => dest.RiskDetails, opt => opt.MapFrom(src => src.RiskDetails))
            .ForMember(dest => dest.RiskCategory, opt => opt.MapFrom(src => src.RiskCategory))
            .ForMember(dest => dest.MitigationPlan, opt => opt.MapFrom(src => src.MitigationPlan))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
        }
    }
}
