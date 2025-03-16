using System.Linq.Expressions;
using ControlPannel.Infrastructure.Data;
using ControlPannel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using controlpannel.domain.RepositoryInterfaces;

namespace controlpannel.infrastructure.Repositories;

public class ConfigurationPasswordRepository : IConfigurationPasswordRepository
{
    private readonly SecurityDbContext _context;

    public ConfigurationPasswordRepository(SecurityDbContext context)
    {
        _context = context;
    }

    public async Task<ConfigurationPassword?> GetByIdAsync(long id)
    {
        return await _context.ConfigurationPasswords
            .Include(cp => cp.Application)
            .FirstOrDefaultAsync(cp => cp.Id == id);
    }

    public async Task<List<ConfigurationPassword>> GetAllAsync(long applicationId, Expression<Func<ConfigurationPassword, object>> sortBy, bool descending)
    {
        IQueryable<ConfigurationPassword> query = _context.ConfigurationPasswords
            .Where(cp => cp.ApplicationId == applicationId);

        query = descending ? query.OrderByDescending(sortBy) : query.OrderBy(sortBy);

        return await query.ToListAsync();
    }



    public async Task AddAsync(ConfigurationPassword configurationPassword)
    {
        await _context.ConfigurationPasswords.AddAsync(configurationPassword);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ConfigurationPassword configurationPassword)
    {
        _context.ConfigurationPasswords.Update(configurationPassword);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var configPassword = await _context.ConfigurationPasswords.FindAsync(id);
        if (configPassword == null) return false;

        _context.ConfigurationPasswords.Remove(configPassword);
        await _context.SaveChangesAsync();
        return true;
    }
}
