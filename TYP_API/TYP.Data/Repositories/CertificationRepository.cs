using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Core.Repositories;

namespace TYP.Data.Repositories
{
    class CertificationRepository : Repository<Certification>, ICertificationRepository
    {
        private readonly AppDbContext _context;

        public CertificationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
