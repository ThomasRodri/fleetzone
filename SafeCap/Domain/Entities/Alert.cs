namespace SafeCap.Domain.Entities
{
    public class Alert
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string AlertType { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public User User { get; set; }

    }
}
