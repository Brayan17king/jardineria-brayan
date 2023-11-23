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

            CreateMap<Cliente, ClienteNombreDto>().ReverseMap();
            CreateMap<Estado, EstadoNombreDto>().ReverseMap();
            CreateMap<Cliente, ClienteIdDto>().ReverseMap();
            CreateMap<Pedido, PedidoIdClienteIdFechaEntregaDto>().ReverseMap();
            CreateMap<Ciudad, OficinaIdCiudadNombreDto>().ReverseMap();
            CreateMap<Oficina, OficinaIdDto>().ReverseMap();
            CreateMap<OficinaIdDto, OficinaIdCiudadNombreDto>().ReverseMap();
            CreateMap<OficinaIdCiudadNombreDto, OficinaIdDto>().ReverseMap();
            CreateMap<Direccion, OficinaIdDto>().ReverseMap();
            CreateMap<Oficina, OficinaIdTelefonoDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoNombreApellidosEmailDto>().ReverseMap();
            CreateMap<Formapago, FormaPagoNombreDto>().ReverseMap();
            CreateMap<Producto, ProductoNormalDto>().ReverseMap();
            CreateMap<Pais, ClientesCantidadPaisDto>().ReverseMap();
            CreateMap<Ciudad, ClientesCantidadCiudadDto>().ReverseMap();
            CreateMap<Cliente, ClientesCantidadDto>().ReverseMap();
            CreateMap<Producto, ProductoMaxDto>().ReverseMap();
            CreateMap<Producto, ProductoMinDto>().ReverseMap();
            CreateMap<Producto, ProductoPrecioMaxDto>().ReverseMap();
            CreateMap<Cliente, ClienteMaxCreditoDto>().ReverseMap();
            CreateMap<Cliente, ClienteSinPagoDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoSoriaDto>().ReverseMap();
            CreateMap<Detallepedido, DetalleNombreDto>().ReverseMap();
            CreateMap<Empleado, ClientesCantidadPaisDto>().ReverseMap();

            CreateMap<Cliente, ClienteRepresentanteVentasDto>().ReverseMap();
            CreateMap<ClientePagosRepresentanteDto, Cliente>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserRegisterDto, UserDto>().ReverseMap();
        }
    }
}