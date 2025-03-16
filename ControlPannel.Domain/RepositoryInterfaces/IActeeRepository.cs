using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Enums;


namespace controlpannel.Domain.Repositories;
    public interface IActeeRepository 
{
    Task<List<Actee>> GetActeesByIdsAsync(List<long> acteeIds);

    Task<Actee> GetByIdAsync(long id);


    Task<Actee> GetByUuidAsync(string uuid);


    Task<List<Actee>> GetAllAsync();
    Task<List<Actee>> GetActeesByApplicationPackageId (long applicationPackageId);


    Task<IEnumerable<Actee>> GetByStatusAsync(StatusTypes status);


    Task<IEnumerable<Actee>> GetByActeeTypeAsync(ActeeTypes acteeType);


    Task<Actee?> GetActeeByApplicationId(long applicationId);

    Task AddAsync(Actee actee);


    Task UpdateAsync(Actee actee);


    Task DeleteAsync(long id);


    Task<int> SaveChangesAsync();

}
