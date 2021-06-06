namespace OnlineBookingAggregatorApp.Infrastructure.Settings
{
    public class SmtpOptions
    {
        public string From { get; set; }
        public string Password { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
    }
}