using Microsoft.AspNetCore.Mvc;
using Teste_API.Dto.Autor;
using Teste_API.Dto.Livro;
using Teste_API.Models;
using Teste_API.Services.Livro;

namespace Teste_API.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]

        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]

        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var livro = await _livroInterface.BuscarLivroPorIdAutor(idAutor);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]

        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livros = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livros);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livros = await _livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(livros);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
        {
            var livros = await _livroInterface.ExcluirLivro(idLivro);
            return Ok(livros);
        }
    }
}
