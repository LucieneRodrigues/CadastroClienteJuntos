using CadastroCliente.Context;
using CadastroCliente.Models;
using CadastroCliente.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Repository;


public class EnderecoRepository : Repository<Enderecos>, IEnderecoRepository
{
    public EnderecoRepository(AppDbContext contexto) : base(contexto)
    {
    }

    public async Task<PagedList<Enderecos>> GetEnderecos(EnderecosParameters enderecosParameters)
    {

        return await PagedList<Enderecos>.ToPagedList(Get().OrderBy(on => on.EnderecoId),
            enderecosParameters.PageNumber, enderecosParameters.PageSize);
    }

    public async Task<IEnumerable<Enderecos>> GetEnderecosPorPreco()
    {
        return await Get().OrderBy(c => c.Rua).ToListAsync();
    }

    public Task<IEnumerable<Enderecos>> GetEnderecosPorRua()
    {
        throw new NotImplementedException();
    }
}