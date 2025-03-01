namespace BusinessService.Contracts.Responses
{
    public class GetBusinessTopicResponse
    {
        public Guid Id { get; set; }
        public string PartnerName { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
    }
}
