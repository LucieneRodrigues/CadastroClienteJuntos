using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCliente.Models;

[Table("Cliente")]
public class Cliente
{
    public Cliente()
    {
        Clientes = new Collection<Cliente>();
    }
    [Key]
    public int ClienteId { get; set; }
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    public string? DataNascimento { get; set; }

    public string? Cpf { get; set; }

    public ICollection<Cliente>? Clientes { get; set; }
}