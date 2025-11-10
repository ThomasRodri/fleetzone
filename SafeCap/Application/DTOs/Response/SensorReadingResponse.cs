namespace SafeCap.Application.DTOs.Response
{
    public class SensorReadingResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public float? Temperature { get; set; }
        public float? Humidity { get; set; }
        public float? Light { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
