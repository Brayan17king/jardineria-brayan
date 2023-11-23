using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers
{
    public class DetallepedidoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GardensContext _context;


        public DetallepedidoController(IUnitOfWork unitOfWork, IMapper mapper, GardensContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }

        [HttpGet] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetallepedidoDto>>> Get()
        {
            var results = await _unitOfWork.Detallepedidos.GetAllAsync();
            return _mapper.Map<List<DetallepedidoDto>>(results);
        }

        [HttpGet("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetallepedidoDto>> Get(int id)
        {
            var result = await _unitOfWork.Detallepedidos.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return _mapper.Map<DetallepedidoDto>(result);
        }

        [HttpPost] // 2611
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetallepedidoDto>> Post(DetallepedidoDto resultDto)
        {
            var result = _mapper.Map<Detallepedido>(resultDto);
            _unitOfWork.Detallepedidos.Add(result);
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
        public async Task<ActionResult<DetallepedidoDto>> Put(int id, DetallepedidoDto resultDto)
        {
            var exists = await _unitOfWork.Detallepedidos.GetByIdAsync(id);
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
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DetallepedidoDto>(exists);
        }

        [HttpDelete("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Detallepedidos.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Detallepedidos.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("ventasProductosMas3000Euros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVentasProductosMas3000Euros()
        {
            var query = from detalle in _context.Detallepedidos
                        where detalle.Cantidad.HasValue && detalle.PrecioUnidad.HasValue
                        group detalle by detalle.IdProductoFk into productos
                        let totalFacturado = productos.Sum(d => d.Cantidad.Value * d.PrecioUnidad.Value)
                        let totalConIVA = totalFacturado * 1.21m // Total facturado con 21% IVA
                        where totalConIVA > 3000
                        select new
                        {
                            IdProducto = productos.Key,
                            TotalFacturado = totalFacturado,
                            TotalConIVA = totalConIVA
                        };

            var productosMas3000Euros = query.ToList();

            var ventasMas3000Euros = productosMas3000Euros.Select(producto =>
                new
                {
                    NombreProducto = _context.Productos.FirstOrDefault(p => p.Id == producto.IdProducto)?.Nombre,
                    UnidadesVendidas = _context.Detallepedidos.Where(d => d.IdProductoFk == producto.IdProducto).Sum(d => d.Cantidad),
                    producto.TotalFacturado,
                    producto.TotalConIVA
                }
            ).ToList();

            return Ok(ventasMas3000Euros);
        }

        [HttpGet("productoMasVendido")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductoMasVendido()
        {
            var query = from detalle in _context.Detallepedidos
                        group detalle by detalle.IdProductoFkNavigation.Nombre into productos
                        orderby productos.Sum(p => p.Cantidad) descending
                        select productos.Key;
            var productoMasVendido = query.FirstOrDefault();
            return Ok(productoMasVendido);
        }
    }
}