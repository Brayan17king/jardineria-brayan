using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class EmpleadoRepository : GenericRepositoryInt<Empleado>, IEmpleado
    {
        private readonly GardensContext _context;

        public EmpleadoRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}