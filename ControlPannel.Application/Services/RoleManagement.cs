using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using controlpannel.application.Dtos.RoleDtos;
using controlpannel.domain.RepositoryInterfaces;
using ControlPannel.Domain.Entities;

namespace controlpannel.application.Services
{
    public class RoleManagement
    {
        private readonly IRoleRepository _roleRepo;
        private readonly IMapper _mapper;

        public RoleManagement(IRoleRepository roleRepo, IMapper mapper)
        {
            _mapper = mapper;
            _roleRepo = roleRepo;
        }

        public async Task<List<RoleDto>> GetAllByApplicationIdAsync(long applicationId, string sortByField, bool descending)
        {
            Expression<Func<Role, object>> sortExpression = sortByField.ToLower() switch
            {
                "title" => cl => cl.Title,
                "status" => cl => cl.Status,
                _ => cl => cl.Id
            };

            var roles = await _roleRepo.GetRolesByApplicationIdAsync(applicationId, sortExpression, descending);
            return _mapper.Map<List<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetByIdAsync(long id)
        {
            var role = await _roleRepo.GetRoleByIdAsync(id);
            return role != null ? _mapper.Map<RoleDto>(role) : null;
        }

        public async Task AddAsync(AddRoleRequestDto dto)
        {
            var entity = _mapper.Map<Role>(dto);
            await _roleRepo.AddRoleAsync(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _roleRepo.DeleteRoleAsync(id);
        }

        public async Task UpdateAsync(UpdateRoleRequestDto dto)
        {
            var entity = _mapper.Map<Role>(dto);
            await _roleRepo.UpdateRoleAsync(entity);
        }
    }
}
