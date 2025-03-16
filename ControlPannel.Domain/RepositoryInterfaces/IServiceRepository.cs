using System;
using System.Linq.Expressions;
using ControlPannel.Domain.Entities;

namespace controlpannel.domain.RepositoryInterfaces;

public interface IServiceRepository
{
    Task<List<Service>> GetAllServicesByActeeIdAsync(long acteeId, Expression<Func<Service, object>> sortBy, bool descending);
    Task AddAsync (Service service);
    Task UpdateAsync (Service service);
    Task <bool> DeleteAsync (long id);
}
