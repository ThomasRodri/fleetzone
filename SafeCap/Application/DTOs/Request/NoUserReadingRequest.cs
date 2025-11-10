namespace SafeCap.Application.DTOs.Request
{
    public class NoUserReadingRequest
    {
        public float? Temperature { get; set; }
        public float? Humidity { get; set; }
        public float? Light { get; set; }
    }
}
