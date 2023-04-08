using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Core.Repositories;

namespace TYP.Data.Repositories
{
    class TeacherPlaceRepository : Repository<TeacherPlace>,ITeacherPlaceRepository
    {
        private readonly AppDbContext _context;

        public TeacherPlaceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
