using Teste_API.Dto.Usuario;
using Teste_API.Models;

namespace Teste_API.Services.AuthService
{
    public interface IAuthInterface
    {

        Task<ResponseModel<UsuarioCriacaoDto>> Registrar(UsuarioCriacaoDto usuarioRegistro);
        Task<ResponseModel<string>> Login(UsuarioLoginDto usuarioLogin);


    }
}
