namespace OnlineBookingAggregatorApp.Infrastructure.Dtos.PolicyRoles
{
    public class PolicyDto
    {
        public long PolicyId { get; set; }
        public string Policy { get; set; }
        public bool IsSetByDefault { get; set; }
    }
}