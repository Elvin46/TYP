﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;

namespace TYP.Service.DTOs.PredmetProfessionDTOs
{
    public class PredmetProfessionMapDTO
    {
        public int PredmetId { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
        public int GeneralHours { get; set; }
        public int OutOfAuditoryHours { get; set; }
        public int AuditoryHours { get; set; }
        public int Lecturer { get; set; }
        public int Seminar { get; set; }
        public int Laboratory { get; set; }
        public bool IsPrerequisite { get; set; }
        public int WeeklyLoad { get; set; }
        public int CategoryId { get; set; }
        public int orderBy { get; set; }
        public int SessionId { get; set; }
    }
}
