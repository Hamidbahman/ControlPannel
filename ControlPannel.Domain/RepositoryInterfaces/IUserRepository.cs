using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Enums;




namespace ControlPannel.Infrastructure.Repositories;
public interface IRoleRepository
{
    Task AddAsync(Role role);
    Task DeleteAsync(long id);
    Task<bool> ExistsAsync(string uuid);


        Task<IEnumerable<Role>> GetAllAsync();


        Task<IEnumerable<Role>> GetByApplicationIdAsync(long applicationId);


        Task<Role?> GetByIdAsync(long id);


        Task<IEnumerable<Role>> GetByStatusAsync(StatusTypes status);


        Task<Role?> GetByUuidAsync(string uuid);


        Task<List<Permission>> GetPermissionsByRoleIdsAsync(List<long> roleIds);


        Task<Role?> GetRoleByIdAsync(long roleId);


        Task<List<Role>> GetRolesByApplicationIdAsync(long applicationId);

        Task<List<Role>> GetRolesByUserIdAsync(long userId);


        Task UpdateAsync(Role role);

    }

