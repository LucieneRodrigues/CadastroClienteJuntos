﻿using CadastroCliente.Models;

namespace CadastroCliente.DTOs;

public class EnderecoDTO
{
    public int EnderecoId { get; set; }  
    public string? Rua { get; set; }

    public string? Numero { get; set; }

    public string Complemento { get; set; }

    public string Bairro { get; set; }

    public string Cep { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }


    public int ClienteId { get; set; }


}