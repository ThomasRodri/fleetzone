namespace SafeCap.Application.DTOs.Response
{
    public class AlertResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string AlertType { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
