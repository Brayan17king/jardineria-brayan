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
    public class PagoRepository : GenericRepositoryString<Pago>, IPago
    {
        private readonly GardensContext _context;

        public PagoRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}