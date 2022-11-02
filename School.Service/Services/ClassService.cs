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
    public class ClassService : IClassService
    {
        private readonly IClassRepository classRepository;
        private readonly ITeacherRepository teacherRepository;

        public ClassService()
        {
            this.teacherRepository = new TeacherRepository();
            this.classRepository = new ClassRepository();
        }
        public async Task<IList<ClassViewModel>> WhereAsync()
        {
            IList<ClassViewModel> classViewModels = (
                from _class in (await classRepository.WhereAsync(x=>true)).ToList()
                join teacher in (await teacherRepository.WhereAsync(x=>true)).ToList() on _class.TeacherId equals teacher.Id
                select new ClassViewModel
                {
                    Id = _class.Id,
                    Name = _class.Name,
                    Tutor = teacher.FirstName + " " + teacher.LastName,
                    PupilsNumber = _class.PupilNumber
                }).ToList();
            return classViewModels;
        }
    }
}
