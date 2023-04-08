using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Core.Entities.Autentication;
using TYP.Data.Configurations;

namespace TYP.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EducationDegree> EducationDegrees { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<FacultyDepartment> FacultyDepartments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Predmet> Predmets { get; set; }
        public DbSet<PredmetProfession> PredmetProfessions { get; set; }
        public DbSet<PredmetGroup> PredmetGroups { get; set; }
        public DbSet<ScientificDegree> ScientificDegrees { get; set; }
        public DbSet<ScientificName> ScientificNames { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<TeacherCertification> TeacherCertifications { get; set; }
        public DbSet<TeacherLanguage> TeacherLanguages { get; set; }
        public DbSet<TeacherSector> TeacherSectors { get; set; }
        public DbSet<TeacherGroup> TeacherGroups { get; set; }
        public DbSet<TeacherPlace> TeacherPlaces { get; set; }
        public DbSet<TeacherPredmet> TeacherPredmets { get; set; }
        public DbSet<TeacherProfession> TeacherProfessions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new PredmetConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
