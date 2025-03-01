using Arch.EntityFrameworkCore.UnitOfWork;
using BusinessService.Data.Abstractions;
using BusinessService.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessService.Data.Repositories
{
    public class RiskAnalysisRepository : Repository<RiskAnalysis>, IRiskAnalysisRepository
    {
        private readonly BusinessServiceDbContext _context;

        public RiskAnalysisRepository(BusinessServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<RiskAnalysis>> GetRiskAnalysisListByBusinessTopicId(Guid businessTopicId)
        {
            return await _context.RiskAnalyses
                .Where(r => r.BusinessTopicId == businessTopicId)
                .ToListAsync();
        }
    }
}
