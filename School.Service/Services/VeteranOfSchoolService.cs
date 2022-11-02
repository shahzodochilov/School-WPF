using School.Data.Interfaces;
using School.Data.Repositories;
using School.Service.Interfaces;
using School.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Services
{
    public class VeteranOfSchoolService : IVeteranOfSchoolService
    {
        private readonly IVeteranOfSchoolRepository veteranOfSchoolRepository;
        private readonly ITeacherRepository teacherRepository;

        public VeteranOfSchoolService()
        {
            this.veteranOfSchoolRepository = new VeteranOfSchoolRepository();
            this.teacherRepository = new TeacherRepository();
        }
        public async Task<IList<VeteranOfSchoolViewModel>> WhereAsync()
        {
            IList<VeteranOfSchoolViewModel> veteranOfSchoolViewModels = (
                from veteranOfSchool in (await veteranOfSchoolRepository.WhereAsync(x => true)).ToList()
                join teacher in (await teacherRepository.WhereAsync(x => true)).ToList() on veteranOfSchool.TeacherId equals teacher.Id
                select new VeteranOfSchoolViewModel
                {
                    Id = veteranOfSchool.Id,
                    TeacherName = teacher.FirstName + " " + teacher.LastName,
                    CreatedDate = veteranOfSchool.CreatedDate
                }).ToList();
            return veteranOfSchoolViewModels;
        }
    }
}
