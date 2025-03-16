using System;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Enums;
using ControlPannel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace controlpannel.infrastructure.Repositories;

public class PermissionRepository
{
    private readonly SecurityDbContext dbContext;

    public PermissionRepository(SecurityDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Permission>> GetPermissionsByRoleIdAsync(long roleId)
    {
        return await dbContext.Permissions
            .Where(p => p.RoleId == roleId)
            .Include(p => p.Actee)
            .ToListAsync();
    }
        public async Task<List<Permission>> GetPermissionsByActeeIdsAsync(List<long> acteeIds)
    {
        return await dbContext.Permissions
                             .Where(p => acteeIds.Contains(p.ActeeId))
                             .ToListAsync();
    }

    public async Task<List<Permission>> GetPermissionsByUserIdAsync(long userId)
    {
        return await dbContext.Permissions
            .Where(p => p.Role.UserRoles.Any(ur => ur.UserId == userId))
            .Include(p => p.Actee)
            .ToListAsync();
    }

    public Task<Permission?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Permission>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Permission>> GetByRoleIdAsync(long roleId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Permission>> GetByActeeIdAsync(long acteeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Permission>> GetByStatusAsync(StatusTypes status)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Permission>> GetByGrantingLevelAsync(int granting)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(long roleId, long acteeId)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Permission permission)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Permission permission)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Mask>> GetMasksByPermissionIdsAsync(List<long> permissionIds)
    {
        throw new NotImplementedException();
    }

    public Task<List<long>> GetPermissionIdsByRolesAsync(List<Role> roles)
    {
        throw new NotImplementedException();
    }

    public Task<List<Permission>> GetPermissionsByRolesAsync(List<long> roleIds)
    {
        throw new NotImplementedException();
    }
}
