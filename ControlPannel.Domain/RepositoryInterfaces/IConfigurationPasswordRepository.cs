using System;
using System.Linq.Expressions;
using ControlPannel.Domain.Entities;



namespace controlpannel.domain.RepositoryInterfaces;
public interface IConfigurationPasswordRepository
{
    Task<ConfigurationPassword?> GetByIdAsync(long id);
    Task<List<ConfigurationPassword>> GetAllAsync(long applicationId, Expression<Func<ConfigurationPassword, object>> sortBy, bool descending);
    Task AddAsync(ConfigurationPassword configurationPassword);
    Task UpdateAsync(ConfigurationPassword configurationPassword);
    Task<bool> DeleteAsync(long id);
}
