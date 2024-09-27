using Teste_API.Models;

namespace Teste_API.Dto.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }
        public AutorModel Autor { get; set; }
    }
}
