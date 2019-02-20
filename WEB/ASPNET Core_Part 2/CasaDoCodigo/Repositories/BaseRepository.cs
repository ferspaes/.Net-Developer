using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<T> DBSet;

        public BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            DBSet = contexto.Set<T>();
        }
    }
}
