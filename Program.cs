using Microsoft.EntityFrameworkCore;
using variacao_ativo;
using variacao_ativo.Model;

var connection = @"Server=(localdb)\mssqllocaldb;Database=AspCore_NovoDB;Trusted_Connection=True;";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PrecoAtivoDB>(opt => opt.UseSqlServer(connection));
var app = builder.Build();

var serviceScopeFactory = (IServiceScopeFactory)app.Services.GetService(typeof(IServiceScopeFactory));

using (var scope = serviceScopeFactory.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PrecoAtivoDB>();

    var lastRegister = context.PrecosAtivos.OrderByDescending(o => o.Id).FirstOrDefault();

    if (lastRegister == null || lastRegister.Data.Date < DateTime.Now.Date)
    {
        var listPreco = await new FinanceAPI().GetRegisters();

        if (lastRegister != null)
        {
            listPreco = listPreco.Where(w => w.Data.Date > lastRegister.Data.Date).ToList();
        }

        context.PrecosAtivos.AddRange(listPreco);
        context.SaveChanges();
    }

}

app.MapGet("/precoativos", async (PrecoAtivoDB db) =>
{
    var listPrecoAtivoExibica = new List<PrecoAtivoExibicaoDTO>();
    var listPrecoAtivoDB = await db.PrecosAtivos.Where(w => w.Data >= DateTime.Now.AddMonths(-1)).ToListAsync();
   
    for (var i = 0;i < listPrecoAtivoDB.Count; i++) 
    {
        decimal? valorPrecoAtivoDiaAnterior = null;

        if (i > 0)
        {
            valorPrecoAtivoDiaAnterior = listPrecoAtivoDB[i - 1].Valor;
        }

        listPrecoAtivoExibica.Add
            (
                new PrecoAtivoExibicaoDTO(listPrecoAtivoDB[i].Data, listPrecoAtivoDB[i].Valor, valorPrecoAtivoDiaAnterior, listPrecoAtivoDB.FirstOrDefault().Valor)
            );
    }

    return listPrecoAtivoExibica;
});

app.Run();