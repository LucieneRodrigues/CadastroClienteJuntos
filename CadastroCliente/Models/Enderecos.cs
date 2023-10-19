using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroCliente.Models
{
    [Table("Endereco")]
    public class Enderecos
    {
        [Key]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Rua { get; set; }

        public string? Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }


        public int ClienteId { get; set; }

        [JsonIgnore]
        public Cliente? Cliente { get; set; }
    }
}