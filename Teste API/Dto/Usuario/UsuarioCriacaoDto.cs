using System.ComponentModel.DataAnnotations;

namespace Teste_API.Dto.Usuario
{
    public class UsuarioCriacaoDto
    {
        [Required(ErrorMessage = "O campo de usuário é obrigatório")]
        public string Usuario {  get; set; }
        [Required(ErrorMessage = "O campo de Email é obrigatório"), EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo de usuário é obrigatório")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo de confirmar senha é obrigatório")]
        [Compare("Senha", ErrorMessage = "Senhas não coincidem!")]
        public string ConfirmarSenha { get; set; }

    }
}
