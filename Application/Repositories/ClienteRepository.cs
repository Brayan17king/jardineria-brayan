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
    public class ClienteRepository : GenericRepositoryInt<Cliente>, ICliente
    {
        private readonly GardensContext _context;

        public ClienteRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}