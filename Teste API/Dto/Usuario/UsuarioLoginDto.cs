using System.ComponentModel.DataAnnotations;

namespace Teste_API.Dto.Usuario
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "O campo de Email é obrigatório"), EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de usuário é obrigatório")]
        public string Senha { get; set; }
    }
}
