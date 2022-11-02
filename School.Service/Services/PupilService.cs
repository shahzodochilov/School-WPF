using School.Data.Interfaces;
using School.Data.Repositories;
using School.Service.Interfaces;
using School.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Services
{
    public class PupilService : IPupilService
    {
        private readonly IPupilRepository pupilRepository;
        private readonly IClassRepository classRepository;

        public PupilService()
        {
            this.pupilRepository = new PupilRepository();
            this.classRepository = new ClassRepository();
        }

        public async Task<IList<PupilViewModel>> WhereAsync()
        {
            var pupils = (await pupilRepository.WhereAsync(x => true)).ToList();
            var classes = (await classRepository.WhereAsync(x => true)).ToList();
            List<PupilViewModel> pupilViewModels = (
                from pupil in pupils
                join _class in classes on pupil.ClassId equals _class.Id
                select new PupilViewModel 
                {
                    Id = pupil.Id,
                    ClassName = _class.Name,
                    FirstName = pupil.FirstName,
                    LastName = pupil.LastName,
                    CreatedDate = pupil.CreatedDate,
                    Gender = pupil.Gender,
                    PhoneNumber = pupil.PhoneNumber
                }).ToList();
            return pupilViewModels;
        }
    }
}
