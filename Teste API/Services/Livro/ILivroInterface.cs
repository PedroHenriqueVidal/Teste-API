using Teste_API.Dto.Livro;
using Teste_API.Models;

namespace Teste_API.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idLivro);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
        Task CriarLivro(object livroCriacaoDto);
    }
}
