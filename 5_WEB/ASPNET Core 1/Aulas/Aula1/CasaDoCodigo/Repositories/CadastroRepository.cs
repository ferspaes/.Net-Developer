using CasaDoCodigo.Models;
using System;

namespace CasaDoCodigo.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto) { }

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            throw new NotImplementedException();
        }
    }
}
