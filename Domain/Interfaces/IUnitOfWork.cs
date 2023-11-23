using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public ICiudad Ciudades { get; } // 2611
        public ICliente Clientes { get; }
        public IDetallepedido Detallepedidos { get; }
        public IDireccion Direcciones { get; }
        public IEmpleado Empleados { get; }
        public IEstado Estados { get; }
        public IFormapago Formapagos { get; }
        public IGamaproducto Gamaproductos { get; }
        public IOficina Oficinas { get; }
        public IPago Pagos { get; }
        public IPais Paises { get; }
        public IPedido Pedidos { get; }
        public IProducto Productos { get; }
        public IProveedor Proveedores { get; }
        public IPuesto Puestos { get; }
        public IRegion Regiones { get; }
    
        Task<int> SaveAsync(); // 2611
    }
}