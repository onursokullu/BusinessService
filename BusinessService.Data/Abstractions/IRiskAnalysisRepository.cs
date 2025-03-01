using Arch.EntityFrameworkCore.UnitOfWork;
using BusinessService.Models;

namespace BusinessService.Data.Abstractions
{
    public interface IRiskAnalysisRepository : IRepository<RiskAnalysis>
    {
        public Task<List<RiskAnalysis>> GetRiskAnalysisListByBusinessTopicId(Guid businessTopicId);

    }
}
