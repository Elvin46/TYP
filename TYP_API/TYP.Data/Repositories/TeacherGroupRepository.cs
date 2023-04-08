using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Core.Repositories;

namespace TYP.Data.Repositories
{
    class TeacherGroupRepository : Repository<TeacherGroup>,ITeacherGroupRepository
    {
        private readonly AppDbContext _context;

        public TeacherGroupRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
