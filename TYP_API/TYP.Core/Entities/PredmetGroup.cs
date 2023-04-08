﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYP.Core.Entities
{
    public class PredmetGroup : BaseEntity
    {
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
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
        public Category Category { get; set; }
        public int orderBy { get; set; }
        public bool IsNow { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
