using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using controlpannel.domain.RepositoryInterfaces;
using ControlPannel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ControlPannel.Infrastructure.Data;

namespace controlpannel.infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SecurityDbContext _context;

        public RoleRepository(SecurityDbContext context)
        {
            _context = context;
        }

        public async Task AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRoleAsync(long id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Role> GetRoleByApplicationIdAsync(long applicationId)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.ApplicationId == applicationId);
        }

        public async Task<Role?> GetRoleByIdAsync(long roleId)
        {
            return await _context.Roles
                .Include(r => r.Application) // Include related data if needed
                .Include(r => r.UserRoles)
                .Include(r => r.Permissions)
                .FirstOrDefaultAsync(r => r.Id == roleId);
        }

        public async Task<IEnumerable<Role>> GetRolesByApplicationIdAsync(long applicationId, Expression<Func<Role, object>> sortBy, bool descending)
        {
            IQueryable<Role> query = _context.Roles.Where(r => r.ApplicationId == applicationId);
            query = descending ? query.OrderByDescending(sortBy) : query.OrderBy(sortBy);

            return await query.ToListAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
