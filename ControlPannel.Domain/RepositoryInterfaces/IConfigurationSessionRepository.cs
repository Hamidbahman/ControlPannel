using System;
using System.Linq.Expressions;
using ControlPannel.Domain.Entities;


namespace controlpannel.domain.RepositoryInterfaces;
public interface IConfigurationSessionRepository
{
    Task<ConfigurationSession?> GetByIdAsync(long id);
    Task<List<ConfigurationSession>> GetAllAsync(long applicationId, Expression<Func<ConfigurationSession, object>> sortBy, bool descending);
    Task AddAsync(ConfigurationSession configurationSession);
    Task UpdateAsync(ConfigurationSession configurationSession);
    Task<bool> DeleteAsync(long id);
}
