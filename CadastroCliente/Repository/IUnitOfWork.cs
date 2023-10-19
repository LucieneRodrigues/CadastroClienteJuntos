namespace CadastroCliente.Repository
{
    public interface IUnitOfWork
    {
        IEnderecoRepository EnderecoRepository { get; }
        IClienteRepository ClienteRepository { get; }
        Task Commit();
    }
}