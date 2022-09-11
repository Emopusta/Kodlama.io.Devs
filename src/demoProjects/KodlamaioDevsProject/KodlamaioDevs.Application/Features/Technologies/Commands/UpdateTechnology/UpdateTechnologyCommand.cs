using AutoMapper;
using KodlamaioDevs.Application.Features.Technologies.Dtos;
using KodlamaioDevs.Application.Features.Technologies.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaioDevs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public UpdatedTechnologyDto Dto { get; set; }


        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology? technologyToUpdate = await _technologyRepository.GetAsync(t => t.Id == request.Dto.Id);

                await _technologyBusinessRules.TechnologyMustExistWhenRequested(technologyToUpdate);

                Technology mappedTechnology = _mapper.Map(request.Dto, technologyToUpdate);
                Technology updatedTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);
                UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);
                return updatedTechnologyDto;

            }
        }
    }
}
