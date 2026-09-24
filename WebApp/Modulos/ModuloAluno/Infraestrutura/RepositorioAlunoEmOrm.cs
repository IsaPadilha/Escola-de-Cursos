using EscolaDeCursos.WebApp.Compartilhado.Dominio;
using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Orm;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno.Dominio;

public sealed class RepositorioAlunoEmOrm : IRepositorioAluno
{
    private readonly EscolaDeCursosDbContext dbContext;
    public RepositorioAlunoEmOrm(EscolaDeCursosDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Cadastrar(Aluno entidade)
    {
        throw new NotImplementedException();
    }

    public bool Editar(Guid idSelecionado, Aluno entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public Aluno? SelecionarPorId(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Aluno> SelecionarTodos()
    {
        return dbContext.Alunos.ToList();
    }
}
