using System.Linq.Expressions;
using ControlPannel.Infrastructure.Data;
using ControlPannel.Domain.Entities;
using controlpannel.domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace controlpannel.infrastructure.Repositories;

public class ConfigurationLockRepository : IConfigurationLockRepository
{
    private readonly SecurityDbContext _context;

    public ConfigurationLockRepository(SecurityDbContext context)
    {
        _context = context;
    }

    public async Task<ConfigurationLock?> GetByIdAsync(long id)
    {
        return await _context.ConfigurationLocks
            .Include(cl => cl.Application)
            .FirstOrDefaultAsync(cl => cl.Id == id);
    }

    public async Task<List<ConfigurationLock>> GetAllAsync(long applicationId, Expression<Func<ConfigurationLock, object>> sortBy, bool descending)
    {
        IQueryable<ConfigurationLock> query = _context.ConfigurationLocks
            .Where(cl => cl.ApplicationId == applicationId);

        query = descending ? query.OrderByDescending(sortBy) : query.OrderBy(sortBy);

        return await query.ToListAsync();
    }

    public async Task AddAsync(ConfigurationLock configurationLock)
    {
        await _context.ConfigurationLocks.AddAsync(configurationLock);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ConfigurationLock configurationLock)
    {
        _context.ConfigurationLocks.Update(configurationLock);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var configLock = await _context.ConfigurationLocks.FindAsync(id);
        if (configLock == null) return false;

        _context.ConfigurationLocks.Remove(configLock);
        await _context.SaveChangesAsync();
        return true;
    }
}
