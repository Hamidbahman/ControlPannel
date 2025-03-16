using System.Linq.Expressions;
using controlpannel.domain.RepositoryInterfaces;
using controlpannel.Domain.Repositories;
using ControlPannel.Domain.Entities;

public class ServiceAndMenuService
{
    private readonly IApplicationRepository _appRepo;
    private readonly IActeeRepository _acteeRepo;
    private readonly IMenuRepository _menuRepo;
    private readonly IServiceRepository _serviceRepo;
    private readonly IApplicationPackageRepository _appPackageRepo;

    public ServiceAndMenuService(
        IServiceRepository serviceRepo,
        IApplicationRepository appRepo,
        IActeeRepository acteeRepo,
        IMenuRepository menuRepo,
        IApplicationPackageRepository appPackageRepo)
    {
        _serviceRepo = serviceRepo;
        _appRepo = appRepo;
        _acteeRepo = acteeRepo;
        _menuRepo = menuRepo;
        _appPackageRepo = appPackageRepo;
    }

    public async Task<MenuServiceResult> GetAllMenusByApplicationId(long applicationId, 
        Expression<Func<Menu, object>> menuSortBy, bool menuDescending,
        Expression<Func<Service, object>> serviceSortBy, bool serviceDescending)
    {
        var applicationPackages = await _appPackageRepo.GetApplicationPackageIdsByApplicationId(applicationId);
        var actees = new List<Actee>();
        var menus = new List<Menu>();
        var services = new List<Service>();

        foreach (var packageId in applicationPackages)
        {
            var acteesByPackage = await _acteeRepo.GetActeesByApplicationPackageId(packageId);
            actees.AddRange(acteesByPackage);

            foreach (var actee in acteesByPackage)
            {
                var acteeMenus = await _menuRepo.GetByActeeIdAsync(actee.Id, menuSortBy, menuDescending);
                menus.AddRange(acteeMenus);

                var acteeServices = await _serviceRepo.GetAllServicesByActeeIdAsync(actee.Id, serviceSortBy, serviceDescending);
                services.AddRange(acteeServices);
            }
        }

        return new MenuServiceResult
        {
            ApplicationPackages = applicationPackages,
            Menus = menus,
            Services = services
        };
    }

    public class MenuServiceResult
    {
        public List<long> ApplicationPackages { get; set; } = new();
        public List<Menu> Menus { get; set; } = new();
        public List<Service> Services { get; set; } = new();
    }
}
