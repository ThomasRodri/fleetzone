namespace SafeCap.Domain.Entities
{
    public class SensorReading
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public float? Temperature { get; set; }
        public float? Humidity { get; set; }
        public float? Light { get; set; }
        public DateTime Timestamp { get; set; }
        public User User { get; set; }

    }
}
