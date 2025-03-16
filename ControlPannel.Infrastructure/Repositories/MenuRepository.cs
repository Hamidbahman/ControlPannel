using System;
using System.Linq.Expressions;
using controlpannel.domain.RepositoryInterfaces;
using ControlPannel.Domain.Entities;
using ControlPannel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



namespace controlpannel.Infrastructure.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly SecurityDbContext _context;

    public MenuRepository(SecurityDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Menu menu)
    {
        await _context.Menus.AddAsync(menu);
        await _context.SaveChangesAsync();
    }

    public Task DeleteAsync(string menuKey)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var menu = await _context.Menus.FindAsync(id);
        if(menu == null) return false;
        _context.Menus.Remove(menu);
        await _context.SaveChangesAsync();
        return true;
    }

    public Task<List<Menu>> GetAllAsync()
    {
        throw new NotImplementedException();
    }



    public async Task<List<Menu>> GetByActeeIdAsync(long acteeId, Expression<Func<Menu, object>> sortBy, bool descending)
    {
        IQueryable<Menu> query = _context.Menus
            .Include(m=>m.ActeeId == acteeId);
            query = descending? query.OrderByDescending(sortBy) : query.OrderBy(sortBy);
            return await query.ToListAsync();
    }

    public Task<Menu?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Menu?> GetByMenuKeyAsync(string menuKey)
    {
        throw new NotImplementedException();
    }

    public async Task<List<string>> GetMenuKeysByActeeIdsAsync(List<long> acteeIds)
    {
        return await _context.Menus
            .Where(m => acteeIds.Contains(m.ActeeId))
            .Select(m => m.MenuKey)
            .ToListAsync();
    }

    public async Task UpdateAsync(Menu menu)
    {
        _context.Menus.Update(menu);
        await _context.SaveChangesAsync();
    }
}

