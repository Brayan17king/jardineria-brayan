using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class DireccionRepository : GenericRepositoryInt<Direccion>, IDireccion
    {
        private readonly GardensContext _context;

        public DireccionRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}