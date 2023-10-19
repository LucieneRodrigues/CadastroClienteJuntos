using CadastroCliente.Models;
using AutoMapper;

namespace CadastroCliente.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Enderecos, EnderecoDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}