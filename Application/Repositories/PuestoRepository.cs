using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class PuestoRepository : GenericRepositoryInt<Puesto>, IPuesto
    {
        private readonly GardensContext _context;

        public PuestoRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}