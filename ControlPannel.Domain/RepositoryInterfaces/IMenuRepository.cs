using System;
using System.Linq.Expressions;
using ControlPannel.Domain.Entities;


namespace controlpannel.domain.RepositoryInterfaces;

public interface IMenuRepository
{

    Task AddAsync(Menu menu);
    Task DeleteAsync(string menuKey);
    Task<List<Menu>> GetAllAsync();
    Task<List<Menu>> GetByActeeIdAsync(long acteeId, Expression<Func<Menu, object>> sortBy, bool descending);
    Task<Menu?> GetByIdAsync(long id);
    Task<Menu?> GetByMenuKeyAsync(string menuKey);
    Task<List<string>> GetMenuKeysByActeeIdsAsync(List<long> acteeIds);
    Task UpdateAsync(Menu menu);
    Task<bool> DeleteAsync(long id);

}

