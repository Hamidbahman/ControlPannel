using System;
using System.Linq.Expressions;
using ControlPannel.Domain.Entities;

namespace controlpannel.domain.RepositoryInterfaces;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetRolesByApplicationIdAsync(long applicationId, Expression<Func<Role, object>> sortBy, bool descending);
    Task AddRoleAsync (Role role);
    Task<bool> DeleteRoleAsync (long id);
    Task UpdateRoleAsync (Role role);
    Task<Role?> GetRoleByIdAsync(long roleId);


}
