using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class OficinaRepository : GenericRepositoryString<Oficina>, IOficina
    {
        private readonly GardensContext _context;

        public OficinaRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}