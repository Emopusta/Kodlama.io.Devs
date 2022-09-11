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

namespace KodlamaioDevs.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology? technologyToDelete = await _technologyRepository.GetAsync(t => t.Id == request.Id);

                await _technologyBusinessRules.TechnologyMustExistWhenRequested(technologyToDelete);

                Technology deletedTechnology = await _technologyRepository.DeleteAsync(technologyToDelete);
                DeletedTechnologyDto deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTechnology);
                return deletedTechnologyDto;

            }
        }
    }
}
