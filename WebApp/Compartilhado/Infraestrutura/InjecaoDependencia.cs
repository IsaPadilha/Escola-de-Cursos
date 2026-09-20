using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Dominio;
using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Arquivos;
using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Infraestrutura;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Orm;

namespace EscolaDeCursos.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        // Configura Persistencia em Arquivo
        services.AddSingleton<ContextoJson>(_ =>
        {
            ContextoJson contexto = new();
            contexto.Carregar();
            return contexto;
        });

        // Configura Persistência em Banco de Dados
        IServiceCollection serviceCollection1 = services.AddDbContext<EscolaDeCursosDbContext>(options =>
        {
            string? connectionString = configuration.GetConnectionString("SqlServerDocker");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"A Connection String \"SqlServerDocker\" não foi encontrada"
                );
            }

            options.UseSqlServer(connectionString);
        });
        IServiceCollection serviceCollection = serviceCollection1;

        services.AddScoped<IRepositorioInstrutor, RepositorioInstrutorEmArquivo>();
        services.AddScoped<IRepositorioAluno, RepositorioAlunoEmArquivo>();
    }
}
