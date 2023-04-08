﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Core.Repositories;

namespace TYP.Data.Repositories
{
    class JobTypeRepository : Repository<JobType>, IJobTypeRepository
    {
        private readonly AppDbContext _context;

        public JobTypeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
