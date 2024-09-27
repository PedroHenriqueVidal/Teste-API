using Microsoft.EntityFrameworkCore;
using Teste_API.Data;
using Teste_API.Dto.Usuario;
using Teste_API.Models;
using Teste_API.Services.SenhaService;

namespace Teste_API.Services.AuthService
{
    public class AuthService : IAuthInterface
    {
        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;

        public AuthService(AppDbContext context, ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }

        public async Task<ResponseModel<string>> Login(UsuarioLoginDto usuarioLogin)
        {
            ResponseModel<string> resposta = new ResponseModel<string>();
            try
            {

                var usuario = await _context.Usuario.FirstOrDefaultAsync(userBanco => userBanco.Email == usuarioLogin.Email);

                if (usuario == null) 
                {
                    resposta.Mensagem = "Cedenciais inválidas!";
                    resposta.Status = false;
                    return resposta;

                }

                if (!_senhaInterface.VerificaSenhaHash(usuarioLogin.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {

                    resposta.Mensagem = "Credenciais inválidas!";
                    resposta.Status = false;
                    return resposta;

                }

                var token = _senhaInterface.CriarToken(usuario);

                resposta.Dados = token;
                resposta.Mensagem = "Usuário logado com sucesso!";


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

            return resposta;
        }

        public async Task<ResponseModel<UsuarioCriacaoDto>> Registrar(UsuarioCriacaoDto usuarioRegistro)
        {
            ResponseModel<UsuarioCriacaoDto> resposta = new ResponseModel<UsuarioCriacaoDto>();
            try
            {

                if (!VerificaSeEmailEUsuarioJaExiste(usuarioRegistro))
                {
                    resposta.Dados = null;
                    resposta.Status = false;
                    resposta.Mensagem = "Usuario/Email já cadastrados";
                    return resposta;
                }

                _senhaInterface.CriarSenhaHash(usuarioRegistro.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                UsuarioModel usuario = new UsuarioModel()
                {
                    Usuario = usuarioRegistro.Usuario,
                    Email = usuarioRegistro.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Usuário criado com sucesso!";


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

            return resposta;
        }

        public bool VerificaSeEmailEUsuarioJaExiste(UsuarioCriacaoDto usuarioRegistro)
        {
            var usuario = _context.Usuario.FirstOrDefault(userBanco => userBanco.Email == usuarioRegistro.Email || userBanco.Usuario == usuarioRegistro.Usuario);

            if (usuario != null) return false;

            return true;
        }
    }
}
