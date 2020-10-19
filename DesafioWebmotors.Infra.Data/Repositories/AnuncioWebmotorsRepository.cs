using DesafioWebmotors.Domain.Entities;
using DesafioWebmotors.Domain.Repositories;

namespace DesafioWebmotors.Infra.Data.Repositories
{
    public class AnuncioWebmotorsRepository : RepositoryBase<AnuncioWebmotors>, IAnuncioWebmotorsRepository
    {
        public AnuncioWebmotorsRepository(DefaultDbContext context) : base(context)
        {

        }
    }
}
