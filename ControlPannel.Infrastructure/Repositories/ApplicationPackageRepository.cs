using System;
using controlpannel.domain.RepositoryInterfaces;
using ControlPannel.Domain.Entities;
using ControlPannel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace controlpannel.infrastructure.Repositories;

public class ApplicationPackageRepository : IApplicationPackageRepository
{
    private readonly SecurityDbContext _context;
    public ApplicationPackageRepository(SecurityDbContext context)
    {
        _context = context;
    }
    
    public async Task<ApplicationPackage?> GetPackageByApplicationIdAsync(long applicationId)
    {
        return await _context.ApplicationPackages
                             .FirstOrDefaultAsync(ap => ap.ApplicationId == applicationId);
    }
    public async Task<List<long>> GetApplicationPackageIdsByApplicationId(long applicationId)
    {
        return await  _context.ApplicationPackages
            .Where(ap => ap.ApplicationId == applicationId)
            .Select(ap => ap.Id)
            .ToListAsync();
    }
}
