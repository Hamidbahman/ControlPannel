using System.Linq.Expressions;
using controlpannel.domain.RepositoryInterfaces;
using ControlPannel.Domain.Entities;
using ControlPannel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace controlpannel.infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly SecurityDbContext _context;
        
        public ApplicationRepository(SecurityDbContext context)
        {
            _context = context;
        }

        public async Task<Aplication?> GetByIdAsync(long id)
        {
            return await _context.Applications.FirstOrDefaultAsync(a => a.Id == id);
        }

        // ✅ Now accepts Expression<Func<T, object>> directly
        public async Task<List<Aplication>> GetAllAsync(Expression<Func<Aplication, object>> sortBy, bool descending)
        {
            IQueryable<Aplication> query = _context.Applications;

            query = descending ? query.OrderByDescending(sortBy) : query.OrderBy(sortBy);

            return await query.ToListAsync();
        }

        public async Task AddAsync(Aplication application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Aplication application)
        {
            _context.Entry(application).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var application = await _context.Applications
                .AsSplitQuery()
                .Include(a => a.Roles)
                .Include(a => a.ApplicationPackages)
                .Include(a => a.ConfigurationSessions)
                .Include(a => a.ConfigurationLocks)
                .Include(a => a.ConfigurationPasswords)
                .FirstOrDefaultAsync(a => a.Id == id);
            
            if (application == null) return false;
            
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Aplication>> GetAllAsync(string? sortField = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public async Task<Aplication?> GetAplicationByTitle(string title)
        {
            return await _context.Applications.FirstOrDefaultAsync(a => a.Title == title);
        }
    }
}
