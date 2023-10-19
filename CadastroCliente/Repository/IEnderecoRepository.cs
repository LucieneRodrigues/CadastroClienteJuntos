using CadastroCliente.Models;
using CadastroCliente.Pagination;

namespace CadastroCliente.Repository;

public interface IEnderecoRepository : IRepository<Enderecos>
{
    Task<PagedList<Enderecos>> GetEnderecos(EnderecosParameters enderecosParameters);
    Task<IEnumerable<Enderecos>> GetEnderecosPorRua();
}