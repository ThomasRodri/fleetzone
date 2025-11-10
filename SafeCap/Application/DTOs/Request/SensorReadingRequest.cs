using System.ComponentModel.DataAnnotations;

namespace SafeCap.Application.DTOs.Request

{
    public class SensorReadingRequest
    {
        [Required(ErrorMessage = "Id do Usuário é obrigatório.")]
        public Guid UserId { get; set; }
        public float? Temperature { get; set; }
        public float? Humidity { get; set; }
        public float? Light { get; set; }
    }
}
