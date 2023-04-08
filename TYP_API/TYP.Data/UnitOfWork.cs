using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core;
using TYP.Core.Repositories;
using TYP.Data.Repositories;

namespace TYP.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ICertificationRepository _certificationRepository;
        private ISectorRepository _sectorRepository;
        private ILanguageRepository _languageRepository;
        private IBookRepository _bookRepository;
        private ITeacherRepository _teacherRepository;
        private IDepartmentRepository _departmentRepository;
        private IEducationDegreeRepository _educationDegreeRepository;
        private IFacultyDepartmentRepository _facultyDepartmentRepository;
        private IFacultyRepository _facultyRepository;
        private IGroupRepository _groupRepository;
        private IJobTypeRepository _jobTypeRepository;
        private IPlaceRepository _placeRepository;
        private IPredmetGroupRepository _predmetGroupRepository;
        private IPredmetProfessionRepository _predmetProfessionRepository;
        private IPredmetRepository _predmetRepository;
        private IProfessionRepository _professionRepository;
        private IScientificDegreeRepository _scientificDegreeRepository;
        private IScientificNameRepository _scientificNameRepository;
        private ISexRepository _sexRepository;
        private ITeacherGroupRepository _teacherGroupRepository;
        private ITeacherPlaceRepository _teacherPlaceRepository;
        private ITeacherPredmetRepository _teacherPredmetRepository;
        private ITeacherProfessionRepository _teacherProfessionRepository;
        private ITeacherCertificationRepository _teacherCertificationRepository;
        private ITeacherLanguageRepository _teacherLanguageRepository;
        private ITeacherSectorRepository _teacherSectorRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICertificationRepository CertificationRepository => _certificationRepository = _certificationRepository ?? new CertificationRepository(_context);
        
        public IBookRepository BookRepository => _bookRepository = _bookRepository ?? new BookRepository(_context);
        
        public ILanguageRepository LanguageRepository => _languageRepository = _languageRepository ?? new LanguageRepository(_context);
        
        public ISectorRepository SectorRepository => _sectorRepository = _sectorRepository ?? new SectorRepository(_context);
        
        public ITeacherRepository TeacherRepository => _teacherRepository = _teacherRepository ?? new TeacherRepository(_context);

        public IDepartmentRepository DepartmentRepository => _departmentRepository = _departmentRepository ?? new DepartmentRepository(_context);

        public IEducationDegreeRepository EducationDegreeRepository => _educationDegreeRepository = _educationDegreeRepository ?? new EducationDegreeRepository(_context);

        public IFacultyDepartmentRepository FacultyDepartmentRepository => _facultyDepartmentRepository = _facultyDepartmentRepository ?? new FacultyDepartmentRepository(_context);

        public IFacultyRepository FacultyRepository => _facultyRepository = _facultyRepository ?? new FacultyRepository(_context);

        public IGroupRepository GroupRepository => _groupRepository = _groupRepository ?? new GroupRepository(_context);

        public IJobTypeRepository JobTypeRepository => _jobTypeRepository = _jobTypeRepository ?? new JobTypeRepository(_context);

        public IPlaceRepository PlaceRepository => _placeRepository = _placeRepository ?? new PlaceRepository(_context);

        public IPredmetGroupRepository PredmetGroupRepository => _predmetGroupRepository = _predmetGroupRepository ?? new PredmetGroupRepository(_context);
        public IPredmetProfessionRepository PredmetProfessionRepository => _predmetProfessionRepository = _predmetProfessionRepository ?? new PredmetProfessionRepository(_context);

        public IPredmetRepository PredmetRepository => _predmetRepository = _predmetRepository ?? new PredmetRepository(_context);

        public IProfessionRepository ProfessionRepository => _professionRepository = _professionRepository ?? new ProfessionRepository(_context);

        public IScientificDegreeRepository ScientificDegreeRepository => _scientificDegreeRepository = _scientificDegreeRepository ?? new ScientificDegreeRepository(_context);

        public IScientificNameRepository ScientificNameRepository => _scientificNameRepository = _scientificNameRepository ?? new ScientificNameRepository(_context);

        public ISexRepository SexRepository => _sexRepository = _sexRepository ?? new SexRepository(_context);

        public ITeacherGroupRepository TeacherGroupRepository => _teacherGroupRepository = _teacherGroupRepository ?? new TeacherGroupRepository(_context);

        public ITeacherPlaceRepository TeacherPlaceRepository => _teacherPlaceRepository = _teacherPlaceRepository ?? new TeacherPlaceRepository(_context);

        public ITeacherPredmetRepository TeacherPredmetRepository => _teacherPredmetRepository = _teacherPredmetRepository ?? new TeacherPredmetRepository(_context);

        public ITeacherProfessionRepository TeacherProfessionRepository => _teacherProfessionRepository = _teacherProfessionRepository ?? new TeacherProfessionRepository(_context);
        
        public ITeacherCertificationRepository TeacherCertificationRepository => _teacherCertificationRepository = _teacherCertificationRepository ?? new TeacherCertificationRepository(_context);
        
        public ITeacherLanguageRepository TeacherLanguageRepository => _teacherLanguageRepository = _teacherLanguageRepository ?? new TeacherLanguageRepository(_context);
        
        public ITeacherSectorRepository TeacherSectorRepository => _teacherSectorRepository = _teacherSectorRepository ?? new TeacherSectorRepository(_context);

       

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
