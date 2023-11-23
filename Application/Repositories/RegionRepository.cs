using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class RegionRepository : GenericRepositoryInt<Region>, IRegion
    {
        private readonly GardensContext _context;

        public RegionRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}