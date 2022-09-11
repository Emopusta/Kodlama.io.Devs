using Core.CrossCuttingConcerns.Exceptions;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules 
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyMustExistWhenRequested(Technology programmingLanguageToDelete)
        {
            if (programmingLanguageToDelete == null) throw new BusinessException("Technology Must be existed");
        }
    }
}
