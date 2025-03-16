using System;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Enums;

namespace controlpannel.domain.RepositoryInterfaces;

public interface IPermissionRepository
{


    Task<List<Permission>> GetPermissionsByRoleIdAsync(long roleId);

    Task<List<Permission>> GetPermissionsByActeeIdsAsync(List<long> acteeIds);


    Task<List<Permission>> GetPermissionsByUserIdAsync(long userId);


    Task<Permission?> GetByIdAsync(long id);


    Task<IEnumerable<Permission>> GetAllAsync();


    Task<IEnumerable<Permission>> GetByRoleIdAsync(long roleId);


    Task<IEnumerable<Permission>> GetByActeeIdAsync(long acteeId);


    Task<IEnumerable<Permission>> GetByStatusAsync(StatusTypes status);


    Task<IEnumerable<Permission>> GetByGrantingLevelAsync(int granting);

    Task<bool> ExistsAsync(long roleId, long acteeId);


    Task AddAsync(Permission permission);


    Task UpdateAsync(Permission permission);


    Task DeleteAsync(long id);


    Task<List<Mask>> GetMasksByPermissionIdsAsync(List<long> permissionIds);


    Task<List<long>> GetPermissionIdsByRolesAsync(List<Role> roles);



}
