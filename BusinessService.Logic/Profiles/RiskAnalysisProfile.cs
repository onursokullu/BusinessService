using AutoMapper;
using BusinessService.Contracts.Responses;
using BusinessService.Models;

namespace BusinessService.Logic.Profiles
{
    public class RiskAnalysisProfile : Profile
    {
        public RiskAnalysisProfile()
        {
            CreateMap<RiskAnalysis, RiskAnalysisListResponse>();
        }
    }
}
