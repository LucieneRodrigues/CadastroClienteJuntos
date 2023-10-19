using CadastroCliente.DTOs;
using CadastroCliente.Models;
using CadastroCliente.Pagination;
using CadastroCliente.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CadastroCliente.Controllers;

[Route("api/[Controller]")]
[ApiController]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ClientesController : ControllerBase
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    public ClientesController(IUnitOfWork contexto, IMapper mapper)
    {
        _context = contexto;
        _mapper = mapper;
    }

    [HttpGet("clientes")]
    public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClienteEndereco()
    {
        var clientes = await _context.ClienteRepository
                        .GetClientesEnderecos();

        var clienteDto = _mapper.Map<List<ClienteDTO>>(clientes);
        return clienteDto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDTO>>>
        Get([FromQuery] ClientesParameters clientesParameters)
    {
        var clientes = await _context.ClienteRepository.
                            GetClientes(clientesParameters);

        var metadata = new
        {
            clientes.TotalCount,
            clientes.PageSize,
            clientes.CurrentPage,
            clientes.TotalPages,
            clientes.HasNext,
            clientes.HasPrevious
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        var clientesDto = _mapper.Map<List<ClienteDTO>>(clientes);
        return clientesDto;
    }

    [HttpGet("{id}", Name = "ObterCliente")]
    public async Task<ActionResult<ClienteDTO>> Get(int id)
    {
        var cliente = await _context.ClienteRepository
                         .GetById(p => p.ClienteId == id);

        if (cliente == null)
        {
            return NotFound();
        }
        var clienteDto = _mapper.Map<ClienteDTO>(cliente);
        return clienteDto;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDto)
    {
        var cliente = _mapper.Map<Cliente>(clienteDto);

        _context.ClienteRepository.Add(cliente);
        await _context.Commit();

        var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

        return new CreatedAtRouteResult("ObterCliente",
            new { id = cliente.ClienteId }, clienteDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO clienteDto)
    {
        if (id != clienteDto.ClienteId)
        {
            return BadRequest();
        }

        var cliente = _mapper.Map<Cliente>(clienteDto);

        _context.ClienteRepository.Update(cliente);
        await _context.Commit();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ClienteDTO>> Delete(int id)
    {
        var cliente = await _context.ClienteRepository
                        .GetById(p => p.ClienteId == id);

        if (cliente == null)
        {
            return NotFound();
        }
        _context.ClienteRepository.Delete(cliente);
        await _context.Commit();

        var clienteDto = _mapper.Map<ClienteDTO>(cliente);

        return clienteDto;
    }
}