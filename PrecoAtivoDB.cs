using Microsoft.EntityFrameworkCore;
using variacao_ativo.Model;

namespace variacao_ativo
{
    class PrecoAtivoDB : DbContext
    {
        public PrecoAtivoDB(DbContextOptions<PrecoAtivoDB> options)
        : base(options) { }

        public DbSet<PrecoAtivoDTO> PrecosAtivos => Set<PrecoAtivoDTO>();
    }
}
