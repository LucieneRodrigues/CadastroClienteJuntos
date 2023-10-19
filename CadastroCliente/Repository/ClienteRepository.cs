using CadastroCliente.Context;
using CadastroCliente.Models;
using CadastroCliente.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CadastroCliente.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public async Task<PagedList<Cliente>> GetClientes(ClientesParameters clienteParameters)
        {
            return await PagedList<Cliente>.ToPagedList(Get().OrderBy(on => on.Nome),
                               clienteParameters.PageNumber,
                               clienteParameters.PageSize);
        }

        public async Task<IEnumerable<Cliente>> GetClientesEnderecos()
        {
            return await Get().Include(x => x.Clientes).ToListAsync();
        }
    }
}