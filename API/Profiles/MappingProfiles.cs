using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Dtos;
using API.DtosSec;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() // Remember adding : Profile in the class
        { // 2611
            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Detallepedido, DetallepedidoDto>().ReverseMap();
            CreateMap<Direccion, DireccionDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Formapago, FormapagoDto>().ReverseMap();
            CreateMap<Gamaproducto, GamaproductoDto>().ReverseMap();
            CreateMap<Oficina, OficinaDto>().ReverseMap();
            CreateMap<Pago, PagoDto>().ReverseMap();
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Proveedor, ProveedorDto>().ReverseMap();
            CreateMap<Puesto, PuestoDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();

            CreateMap<Pedido, PedidoIdClienteIdFechaEntregaDto>().ReverseMap();
        }
    }
}