using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class EstadoRepository : GenericRepositoryInt<Estado>, IEstado
    {
        private readonly GardensContext _context;

        public EstadoRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}