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
    public class FormapagoRepository : GenericRepositoryInt<Formapago>, IFormapago
    {
        private readonly GardensContext _context;

        public FormapagoRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}