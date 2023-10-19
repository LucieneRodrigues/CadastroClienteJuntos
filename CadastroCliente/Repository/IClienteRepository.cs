using CadastroCliente.Models;
using CadastroCliente.Pagination;

namespace CadastroCliente.Repository;

public interface IClienteRepository : IRepository<Cliente>
{
    Task<PagedList<Cliente>> GetClientes(ClientesParameters clienteParameters);
    Task<IEnumerable<Cliente>> GetClientesEnderecos();
}