namespace CadastroCliente.DTOs;

public class ClienteDTO
{
    public int ClienteId { get; set; }
    public string? Nome { get; set; }

    public string? DataNascimento { get; set; }

    public string? Cpf { get; set; }

    public ICollection<EnderecoDTO>? Enderecos { get; set; }
}