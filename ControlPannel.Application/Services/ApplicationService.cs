using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using controlpannel.application.Dtos;
using controlpannel.Application.Dtos;
using controlpannel.domain.RepositoryInterfaces;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Enums;

namespace controlpannel.application.Services
{
    public class ApplicationService
    {
        private readonly IApplicationRepository _appRepo;
        private readonly IMapper _mapper;
        
        public ApplicationService(IApplicationRepository appRepo, IMapper mapper)
        {
            _appRepo = appRepo;
            _mapper = mapper;
        }

        public async Task<ApplicationDto> CreateApplicationAsync(AddApplicationRequestDto dto)
        {
            var application = _mapper.Map<Aplication>(dto);
            await _appRepo.AddAsync(application);
            return _mapper.Map<ApplicationDto>(application);
        }

        public async Task<ApplicationDto?> GetApplicationByTitle (string title)
        {
            var application = await _appRepo.GetAplicationByTitle(title);
        
                return application != null ? _mapper.Map<ApplicationDto>(application) : null;

        }

        public async Task<ApplicationDto?> GetApplicationByIdAsync(long id)
        {
            var application = await _appRepo.GetByIdAsync(id);
            return application != null ? _mapper.Map<ApplicationDto>(application) : null;
        }

        public async Task<List<ApplicationDto>> GetAllApplicationsAsync(AplicationSortingRequestDto sortingRequest)
        {
            Expression<Func<Aplication, object>> sortExpression = sortingRequest.SortByField?.ToLower() switch
            {
                "title" => a => a.Title,
                "clientid" => a => a.ClientId,
                "status" => a => a.Status,
                "createdate" => a => a.CreateDate,
                "modifydate" => a => a.ModifyDate,
                _ => a => a.Id
            };

            var applications = await _appRepo.GetAllAsync(sortExpression, sortingRequest.Descending);
            return _mapper.Map<List<ApplicationDto>>(applications);
        }

        public async Task<bool> UpdateApplicationAsync(UpdateApplicationRequestDto dto)
        {
            var application = await _appRepo.GetByIdAsync(dto.Id);
            if (application == null) return false;

            _mapper.Map(dto, application);
            await _appRepo.UpdateAsync(application);
            return true;
        }

        public async Task<bool> DeleteApplicationAsync(long id)
        {
            return await _appRepo.DeleteAsync(id);
        }
    }
}
