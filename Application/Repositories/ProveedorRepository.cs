using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class ProveedorRepository : GenericRepositoryInt<Proveedor>, IProveedor
    {
        private readonly GardensContext _context;

        public ProveedorRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}