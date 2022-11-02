using School.Data.Interfaces;
using School.Data.Repositories;
using School.Domain.Entities;
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
    public class PrideOfSchoolService : IPrideOfSchoolService
    {
        private readonly IPrideOfSchoolRepository prideOfSchoolRepository;
        private readonly IPupilRepository pupilRepository;

        public PrideOfSchoolService()
        {
            this.prideOfSchoolRepository = new PrideOfSchoolRepository();
            this.pupilRepository = new PupilRepository();
        }

        public async Task<IList<PrideOfSchoolViewModel>> WhereAsync()
        {
            IList<PrideOfSchoolViewModel> prideOfSchoolViewModels = (
                from prideOfSchool in (await prideOfSchoolRepository.WhereAsync(x=>true)).ToList()
                join pupil in (await pupilRepository.WhereAsync(x=>true)).ToList() on prideOfSchool.PupilId equals pupil.Id
                select new PrideOfSchoolViewModel
                {
                    Id = prideOfSchool.Id,
                    PupilName = pupil.FirstName + " " + pupil.LastName,
                    CreatedDate = prideOfSchool.CreatedDate
                }).ToList();
            return prideOfSchoolViewModels;
        }
    }
}
