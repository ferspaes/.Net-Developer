using CasaDoCodigo.Models;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto) { }

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDB = GetCadastro(cadastroId);

            if (cadastroDB == null)
                throw new ArgumentException("Cadastro não encontrado.");

            cadastroDB.Update(novoCadastro);
            contexto.SaveChanges();
            return cadastroDB;
        }

        public Cadastro GetCadastro(int cadastroId) => DBSet
                    .Where(cadastro => cadastro.Id == cadastroId)
                    .SingleOrDefault();
    }
}
