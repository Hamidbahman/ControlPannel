using System;
using System.Linq.Expressions;
using ControlPannel.Domain.Entities;



namespace controlpannel.domain.RepositoryInterfaces;
public interface IConfigurationLockRepository
{
    Task<ConfigurationLock?> GetByIdAsync(long id);
    Task<List<ConfigurationLock>> GetAllAsync(long applicationId, Expression<Func<ConfigurationLock, object>> sortBy, bool descending);
    Task AddAsync(ConfigurationLock configurationLock);
    Task UpdateAsync(ConfigurationLock configurationLock);
    Task<bool> DeleteAsync(long id);
}
