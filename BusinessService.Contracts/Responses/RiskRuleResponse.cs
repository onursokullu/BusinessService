namespace BusinessService.Contracts.Responses
{
    public class RiskRuleResponse
    {
        public string Name { get; set; }
        public string? Expression { get; set; }
        public List<RiskRuleParameterResponse> Parameters { get; set; }
    }
}
