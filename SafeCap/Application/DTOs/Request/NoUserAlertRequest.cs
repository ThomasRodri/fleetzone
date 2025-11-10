using System.ComponentModel.DataAnnotations;

namespace SafeCap.Application.DTOs.Request
{
    public class NoUserAlertRequest
    {
        [Required(ErrorMessage = "Tipo do Alerta é obrigatório.")]
        public string AlertType { get; set; }
        [Required(ErrorMessage = "Mensagem é obrigatório.")]
        public string Message { get; set; }
    }
}
