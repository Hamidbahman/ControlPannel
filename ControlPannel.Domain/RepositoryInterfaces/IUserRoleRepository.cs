using System;
using ControlPannel.Domain.Entities;




namespace controlpannel.domain.RepositoryInterfaces;
public interface IUserRoleRepository
{
    Task<IEnumerable<UserRole>> GetAllAsync();
    Task<UserRole?> GetByIdAsync(long id);
    Task<IEnumerable<UserRole>> GetByUserIdAsync(long userId);
    Task<List<Role>> GetRolesByUserIdAsync(long userId);
    Task<IEnumerable<UserRole>> GetByRoleIdAsync(long roleId);
    Task AddAsync(UserRole userRole);
    Task UpdateAsync(UserRole userRole);
    Task DeleteAsync(long id);

}
