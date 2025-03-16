using System.Linq.Expressions;
using ControlPannel.Infrastructure.Data;
using ControlPannel.Domain.Entities;
using controlpannel.domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace controlpannel.infrastructure.Repositories;

public class ConfigurationSessionRepository : IConfigurationSessionRepository
{
    private readonly SecurityDbContext _context;

    public ConfigurationSessionRepository(SecurityDbContext context)
    {
        _context = context;
    }

    public async Task<ConfigurationSession?> GetByIdAsync(long id)
    {
        return await _context.ConfigurationSessions
            .Include(cs => cs.Application)
            .FirstOrDefaultAsync(cs => cs.Id == id);
    }

    public async Task<List<ConfigurationSession>> GetAllAsync(long applicationId, Expression<Func<ConfigurationSession, object>> sortBy, bool descending)
    {
        var query = _context.ConfigurationSessions
            .Where(cs => cs.ApplicationId == applicationId);

        query = descending ? query.OrderByDescending(sortBy) : query.OrderBy(sortBy);

        return await query.ToListAsync();
    }

    public async Task AddAsync(ConfigurationSession configurationSession)
    {
        await _context.ConfigurationSessions.AddAsync(configurationSession);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ConfigurationSession configurationSession)
    {
        _context.ConfigurationSessions.Update(configurationSession);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var configSession = await _context.ConfigurationSessions.FindAsync(id);
        if (configSession == null) return false;

        _context.ConfigurationSessions.Remove(configSession);
        await _context.SaveChangesAsync();
        return true;
    }
}
