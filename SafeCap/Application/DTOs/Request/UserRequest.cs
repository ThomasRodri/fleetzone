using System.ComponentModel.DataAnnotations;

namespace SafeCap.Application.DTOs.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
    }
}
