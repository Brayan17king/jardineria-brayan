using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GardensContext _context;
        private ICiudad _Ciudades; // 2611
        private ICliente _Clientes;
        private IDetallepedido _Detallepedidos;
        private IDireccion _Direcciones;
        private IEmpleado _Empleados;
        private IEstado _Estados;
        private IFormapago _Formapagos;
        private IGamaproducto _Gamaproductos;
        private IOficina _Oficinas;
        private IPago _Pagos;
        private IPais _Paises;
        private IPedido _Pedidos;
        private IProducto _Productos;
        private IProveedor _Proveedores;
        private IPuesto _Puestos;
        private IRegion _Regiones;

        public UnitOfWork(GardensContext context)
        {
            _context = context;
        }

        public ICiudad Ciudades // 2611
        {
            get
            {
                if (_Ciudades == null)
                {
                    _Ciudades = new CiudadRepository(_context);
                }
                return _Ciudades;
            }
        }
        public ICliente Clientes // 2611
        {
            get
            {
                if (_Clientes == null)
                {
                    _Clientes = new ClienteRepository(_context);
                }
                return _Clientes;
            }
        }
        public IDetallepedido Detallepedidos // 2611
        {
            get
            {
                if (_Detallepedidos == null)
                {
                    _Detallepedidos = new DetallepedidoRepository(_context);
                }
                return _Detallepedidos;
            }
        }
        public IDireccion Direcciones // 2611
        {
            get
            {
                if (_Direcciones == null)
                {
                    _Direcciones = new DireccionRepository(_context);
                }
                return _Direcciones;
            }
        }
        public IEmpleado Empleados // 2611
        {
            get
            {
                if (_Empleados == null)
                {
                    _Empleados = new EmpleadoRepository(_context);
                }
                return _Empleados;
            }
        }
        public IEstado Estados // 2611
        {
            get
            {
                if (_Estados == null)
                {
                    _Estados = new EstadoRepository(_context);
                }
                return _Estados;
            }
        }
        public IFormapago Formapagos // 2611
        {
            get
            {
                if (_Formapagos == null)
                {
                    _Formapagos = new FormapagoRepository(_context);
                }
                return _Formapagos;
            }
        }
        public IGamaproducto Gamaproductos // 2611
        {
            get
            {
                if (_Gamaproductos == null)
                {
                    _Gamaproductos = new GamaproductoRepository(_context);
                }
                return _Gamaproductos;
            }
        }
        public IOficina Oficinas // 2611
        {
            get
            {
                if (_Oficinas == null)
                {
                    _Oficinas = new OficinaRepository(_context);
                }
                return _Oficinas;
            }
        }
        public IPago Pagos // 2611
        {
            get
            {
                if (_Pagos == null)
                {
                    _Pagos = new PagoRepository(_context);
                }
                return _Pagos;
            }
        }
        public IPais Paises // 2611
        {
            get
            {
                if (_Paises == null)
                {
                    _Paises = new PaisRepository(_context);
                }
                return _Paises;
            }
        }
        public IPedido Pedidos // 2611
        {
            get
            {
                if (_Pedidos == null)
                {
                    _Pedidos = new PedidoRepository(_context);
                }
                return _Pedidos;
            }
        }
        public IProducto Productos // 2611
        {
            get
            {
                if (_Productos == null)
                {
                    _Productos = new ProductoRepository(_context);
                }
                return _Productos;
            }
        }
        public IProveedor Proveedores // 2611
        {
            get
            {
                if (_Proveedores == null)
                {
                    _Proveedores = new ProveedorRepository(_context);
                }
                return _Proveedores;
            }
        }
        public IPuesto Puestos // 2611
        {
            get
            {
                if (_Puestos == null)
                {
                    _Puestos = new PuestoRepository(_context);
                }
                return _Puestos;
            }
        }
        public IRegion Regiones // 2611
        {
            get
            {
                if (_Regiones == null)
                {
                    _Regiones = new RegionRepository(_context);
                }
                return _Regiones;
            }
        }

        public Task<int> SaveAsync() // 2611
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}