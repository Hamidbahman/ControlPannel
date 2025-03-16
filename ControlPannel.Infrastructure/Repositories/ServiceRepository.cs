using System;
using System.Linq.Expressions;
using controlpannel.domain.RepositoryInterfaces;
using ControlPannel.Domain.Entities;
using ControlPannel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace controlpannel.infrastructure.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly SecurityDbContext _context;
    public ServiceRepository(SecurityDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var service = await _context.Services.FindAsync(id);
        if(service == null) return false;
        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Service>> GetAllServicesByActeeIdAsync(long acteeId,  Expression<Func<Service, object>> sortBy, bool descending)
    {
        IQueryable<Service> query = _context.Services
            .Where(s=> s.ActeeId == acteeId);
            query = descending? query.OrderByDescending(sortBy) : query.OrderBy(sortBy);
            return await query.ToListAsync();
    }


    public async Task UpdateAsync(Service service)
    {
         _context.Services.Update(service);
         await _context.SaveChangesAsync();
    }
}