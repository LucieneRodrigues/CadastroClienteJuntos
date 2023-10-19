using CadastroCliente.DTOs;
using CadastroCliente.Models;
using CadastroCliente.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EnderecosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public EnderecosController(IUnitOfWork contexto, IMapper mapper)
        {
            _uof = contexto;
            _mapper = mapper;
        }



        // api/enderecos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> Get()
        {
            var endereco = await _uof.EnderecoRepository.Get().ToListAsync();

            var enderecoDto = _mapper.Map<List<EnderecoDTO>>(endereco);
            return enderecoDto;
        }

        // api/enderecos/1
        [HttpGet("{id}", Name = "ObterEndereco")]
        public async Task<ActionResult<EnderecoDTO>> Get(int id)
        {
            var endereco = await _uof.EnderecoRepository.GetById(p => p.EnderecoId == id);

            if (endereco == null)
            {
                return NotFound();
            }

            var enderecoDto = _mapper.Map<EnderecoDTO>(endereco);
            return enderecoDto;
        }

        //  api/enderecos
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EnderecoDTO enderecoDto)
        {
            var endereco = _mapper.Map<Enderecos>(enderecoDto);

            _uof.EnderecoRepository.Add(endereco);
            await _uof.Commit();

            var enderecoDTO = _mapper.Map<EnderecoDTO>(endereco);

            return new CreatedAtRouteResult("ObterEndereco",
               new { id = endereco.EnderecoId }, enderecoDTO);
        }

        // api/enderecos/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EnderecoDTO enderecoDto)
        {
            if (id != enderecoDto.EnderecoId)
            {
                return BadRequest();
            }

            var endereco = _mapper.Map<Enderecos>(enderecoDto);

            _uof.EnderecoRepository.Update(endereco);

            await _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EnderecoDTO>> Delete(int id)
        {
            var endereco = await _uof.EnderecoRepository.GetById(e => e.EnderecoId == id);

            if (endereco == null)
            {
                return NotFound();
            }

            _uof.EnderecoRepository.Delete(endereco);
            await _uof.Commit();

            var enderecoDto = _mapper.Map<EnderecoDTO>(endereco);

            return enderecoDto;
        }
    }
}