using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controlpannel.Domain.Repositories;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Enums;
using ControlPannel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace controlpannel.infrastructure.Repositories;
    public class ActeeRepository : IActeeRepository
{
    private readonly SecurityDbContext dbContext;

    public ActeeRepository(SecurityDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Actee>> GetActeesByIdsAsync(List<long> acteeIds)
    {
        return await dbContext.Actees
            .Where(a => acteeIds.Contains(a.Id))
            .ToListAsync();
    }
        public async Task<List<Actee>> GetActeesByApplicationPackageIdAsync(long applicationPackageId)
    {
        return await dbContext.Actees
                             .Where(a => a.ApplicationPackageId == applicationPackageId)
                             .ToListAsync();
    }

    public Task<Actee> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Actee> GetByUuidAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Actee>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Actee>> GetByStatusAsync(StatusTypes status)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Actee>> GetByActeeTypeAsync(ActeeTypes acteeType)
    {
        throw new NotImplementedException();
    }

    public Task<Actee?> GetActeeByApplicationId(long applicationId)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Actee actee)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Actee actee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Actee>> GetActeesByApplicationPackageId(long applicationPackageId)
    {
    return await dbContext.Actees
        .Where(ac => ac.ApplicationPackageId == applicationPackageId)
        .Include(ac => ac.Menus)   
        .Include(ac => ac.Services) 
        .ToListAsync();
    }

    Task<List<Actee>> IActeeRepository.GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
