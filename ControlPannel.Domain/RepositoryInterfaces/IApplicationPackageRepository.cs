using System;
using ControlPannel.Domain.Entities;

namespace controlpannel.domain.RepositoryInterfaces;

public interface IApplicationPackageRepository
{
Task<ApplicationPackage?> GetPackageByApplicationIdAsync(long applicationId);

Task<List<long>> GetApplicationPackageIdsByApplicationId(long applicationId);

}

