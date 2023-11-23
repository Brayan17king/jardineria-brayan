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
    public class ProductoRepository : GenericRepositoryString<Producto>, IProducto
    {
        private readonly GardensContext _context;

        public ProductoRepository(GardensContext context) : base(context)
        {
            _context = context;
        }
    }
}