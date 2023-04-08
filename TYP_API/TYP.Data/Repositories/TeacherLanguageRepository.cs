using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Core.Repositories;

namespace TYP.Data.Repositories
{
    class TeacherLanguageRepository : Repository<TeacherLanguage>, ITeacherLanguageRepository
    {
        private readonly AppDbContext _context;

        public TeacherLanguageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
