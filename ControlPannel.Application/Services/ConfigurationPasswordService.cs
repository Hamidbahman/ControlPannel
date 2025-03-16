using System.Linq.Expressions;
using AutoMapper;
using controlpannel.application.Dtos;
using controlpannel.application.Dtos.ConfigurationPassword;
using controlpannel.domain.RepositoryInterfaces;
using ControlPannel.Domain.Entities;

namespace controlpannel.application.Services;

public class ConfigurationPasswordService
{
    private readonly IConfigurationPasswordRepository _repository;
    private readonly IMapper _mapper;

    public ConfigurationPasswordService(IConfigurationPasswordRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ConfigurationPasswordDto>> GetAllByApplicationIdAsync(long applicationId, string sortByField, bool descending)
    {
        Expression<Func<ConfigurationPassword, object>> sortExpression = sortByField.ToLower() switch
        {
            "ispolicyneeded" => cp => cp.IsPolicyNeeded,
            "willpasswordexpire" => cp => cp.WillPassExpire,
            "iscomplex" => cp => cp.IsComplex,
            _ => cp => cp.Id // Default sorting by Id
        };

        var passwords = await _repository.GetAllAsync(applicationId, sortExpression, descending);
        return _mapper.Map<List<ConfigurationPasswordDto>>(passwords);
    }

    public async Task<ConfigurationPasswordDto?> GetByIdAsync(long id)
    {
        var passwordConfig = await _repository.GetByIdAsync(id);
        return _mapper.Map<ConfigurationPasswordDto>(passwordConfig);
    }

    public async Task AddAsync(AddConfigurationPasswordRequestDto dto)
    {
        var entity = _mapper.Map<ConfigurationPassword>(dto);
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(UpdateConfigurationPasswordRequestDto dto)
    {
        var entity = _mapper.Map<ConfigurationPassword>(dto);
        await _repository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }
}
