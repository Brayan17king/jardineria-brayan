using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.DtosSec;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Data;

namespace API.Controllers
{

    public class PedidoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GardensContext _context;

        public PedidoController(IUnitOfWork unitOfWork, IMapper mapper, GardensContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> Get()
        {
            var results = await _unitOfWork.Pedidos.GetAllAsync();
            return _mapper.Map<List<PedidoDto>>(results);
        }

        [HttpGet("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PedidoDto>> Get(int id)
        {
            var result = await _unitOfWork.Pedidos.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<PedidoDto>(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PedidoDto>> Post(PedidoDto resultDto)
        {
            var result = _mapper.Map<Pedido>(resultDto);
            if (resultDto.FechaPedido == DateOnly.MinValue)
            {
                resultDto.FechaPedido = DateOnly.FromDateTime(DateTime.Now);
                result.FechaPedido = DateOnly.FromDateTime(DateTime.Now);
            }
            if (resultDto.FechaEsperada == DateOnly.MinValue)
            {
                resultDto.FechaEsperada = DateOnly.FromDateTime(DateTime.Now);
                result.FechaEsperada = DateOnly.FromDateTime(DateTime.Now);
            }
            if (resultDto.FechaEntrega == DateOnly.MinValue)
            {
                resultDto.FechaEntrega = DateOnly.FromDateTime(DateTime.Now);
                result.FechaEntrega = DateOnly.FromDateTime(DateTime.Now);
            }
            _unitOfWork.Pedidos.Add(result);
            await _unitOfWork.SaveAsync();
            if (result == null)
            {
                return BadRequest();
            }
            resultDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = resultDto.Id }, resultDto);
        }

        [HttpPut("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PedidoDto>> Put(int id, PedidoDto resultDto)
        {
            var exists = await _unitOfWork.Pedidos.GetByIdAsync(id);
            if (exists == null)
            {
                return NotFound();
            }
            if (resultDto.Id == 0)
            {
                resultDto.Id = id;
            }
            if (resultDto.Id != id)
            {
                return BadRequest();
            }
            _mapper.Map(resultDto, exists);
            if (resultDto.FechaPedido == DateOnly.MinValue)
            {
                exists.FechaPedido = DateOnly.FromDateTime(DateTime.Now);
            }
            if (resultDto.FechaEsperada == DateOnly.MinValue)
            {
                exists.FechaEsperada = DateOnly.FromDateTime(DateTime.Now);
            }
            if (resultDto.FechaEntrega == DateOnly.MinValue)
            {
                exists.FechaEntrega = DateOnly.FromDateTime(DateTime.Now);
            }
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PedidoDto>(exists);
        }

        [HttpDelete("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Pedidos.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Pedidos.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("pedidotarde")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<PedidoIdClienteIdFechaEntregaDto>>> GetPedidoTarde()
        {
            var result = await _unitOfWork.Pedidos.GetPedidosTardeAsync();
            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }
            return _mapper.Map<List<PedidoIdClienteIdFechaEntregaDto>>(result);
        }
    }
}