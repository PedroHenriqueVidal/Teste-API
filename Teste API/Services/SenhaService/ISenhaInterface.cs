using Teste_API.Models;

namespace Teste_API.Services.SenhaService
{
    public interface ISenhaInterface
    {

        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);

        bool VerificaSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt);

        string CriarToken(UsuarioModel usuario);


    }
}
