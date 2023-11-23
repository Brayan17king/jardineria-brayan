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
    public class ClienteController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GardensContext _context;

        public ClienteController(IUnitOfWork unitOfWork, IMapper mapper, GardensContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        {
            var results = await _unitOfWork.Clientes.GetAllAsync();
            return _mapper.Map<List<ClienteDto>>(results);
        }


        [HttpGet("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var result = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClienteDto>(result);
        }

        [HttpPost] // 2611
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Post(ClienteDto resultDto)
        {
            var result = _mapper.Map<Cliente>(resultDto);
            _unitOfWork.Clientes.Add(result);
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
        public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody] ClienteDto resultDto)
        {
            var exists = await _unitOfWork.Clientes.GetByIdAsync(id);
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
            // Update the properties of the existing entity with values from resultDto
            _mapper.Map(resultDto, exists);
            // The context is already tracking result, so no need to attach it
            await _unitOfWork.SaveAsync();
            // Return the updated entity
            return _mapper.Map<ClienteDto>(exists);
        }

        [HttpDelete("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Clientes.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Clientes.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("clientesConCantidadPedidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetClientesConCantidadPedidos()
        {
            var query = from cliente in _context.Clientes
                        join pedido in _context.Pedidos on cliente.Id equals pedido.IdClienteFk into clientePedidos
                        select new
                        {
                            NombreCliente = cliente.Nombre,
                            CantidadPedidos = clientePedidos.Count()
                        };

            var resultado = query.ToList();

            return Ok(resultado);
        }

        [HttpGet("clientesRepresentantesCiudad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetClientesRepresentantesCiudad()
        {
            var query = from cliente in _context.Clientes
                        join representante in _context.Empleados on cliente.IdEmpleadoRepresentanteVentasFk equals representante.Id
                        join direccionRepresentante in _context.Direcciones on representante.IdDireccionFk equals direccionRepresentante.Id
                        join ciudadRepresentante in _context.Ciudades on direccionRepresentante.IdCiudadFk equals ciudadRepresentante.Id
                        select new
                        {
                            NombreCliente = cliente.Nombre,
                            NombreRepresentante = representante.Nombre,
                            CiudadRepresentante = ciudadRepresentante.Nombre
                        };

            List<object> result = query.ToList<object>();

            return Ok(result);
        }

        [HttpGet("clientesPagosRepresentantesCiudad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetClientesPagosRepresentantesCiudad()
        {
            var query = (from pago in _context.Pagos
                            join cliente in _context.Clientes on pago.IdClienteFk equals cliente.Id
                            join representante in _context.Empleados on cliente.IdEmpleadoRepresentanteVentasFk equals representante.Id
                            join direccionRepresentante in _context.Direcciones on representante.IdDireccionFk equals direccionRepresentante.Id
                            join ciudadRepresentante in _context.Ciudades on direccionRepresentante.IdCiudadFk equals ciudadRepresentante.Id
                            select new
                            {
                                NombreCliente = cliente.Nombre,
                                NombreRepresentante = representante.Nombre,
                                CiudadRepresentante = ciudadRepresentante.Nombre
                            }).Distinct();
            List<object> result = query.ToList<object>();
            return Ok(result);
        }
    }
}