using CadastroCliente.Context;

namespace CadastroCliente.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private EnderecoRepository _enderecoRepo;
        private ClienteRepository _clienteRepo;
        public AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IEnderecoRepository EnderecoRepository
        {
            get
            {
                return _enderecoRepo = _enderecoRepo ?? new EnderecoRepository(_context);
            }
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepo = _clienteRepo ?? new ClienteRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}