using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYP.Core.Repositories;

namespace TYP.Core
{
    public interface IUnitOfWork
    {
        public IBookRepository BookRepository { get; }
        public ICertificationRepository CertificationRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IEducationDegreeRepository EducationDegreeRepository { get; }
        public IFacultyDepartmentRepository FacultyDepartmentRepository { get; }
        public IFacultyRepository FacultyRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IJobTypeRepository JobTypeRepository { get; }
        public ILanguageRepository LanguageRepository{ get; }
        public IPlaceRepository PlaceRepository { get; }
        public IPredmetProfessionRepository PredmetProfessionRepository { get; }
        public IPredmetGroupRepository PredmetGroupRepository { get; }
        public IPredmetRepository PredmetRepository { get; }
        public IProfessionRepository ProfessionRepository { get; }
        public IScientificDegreeRepository ScientificDegreeRepository { get; }
        public IScientificNameRepository ScientificNameRepository { get; }
        public ISectorRepository SectorRepository { get; }
        public ISexRepository SexRepository { get; }
        public ITeacherCertificationRepository TeacherCertificationRepository { get; }
        public ITeacherGroupRepository TeacherGroupRepository { get; }
        public ITeacherLanguageRepository TeacherLanguageRepository { get; }
        public ITeacherPlaceRepository TeacherPlaceRepository { get; }
        public ITeacherPredmetRepository TeacherPredmetRepository { get; }
        public ITeacherProfessionRepository TeacherProfessionRepository { get; }
        public ITeacherRepository TeacherRepository { get; }
        public ITeacherSectorRepository TeacherSectorRepository { get; }


        Task CommitAsync();
    }
}
