using System.ComponentModel.DataAnnotations;

namespace SafeCap.Application.DTOs.Request
{
    public class AlertRequest
    {
        [Required(ErrorMessage = "Id do Usuário é obrigatório.")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Tipo do Alerta é obrigatório.")]
        public string AlertType { get; set; }
        [Required(ErrorMessage = "Mensagem é obrigatório.")]
        public string Message { get; set; }
    }
}
