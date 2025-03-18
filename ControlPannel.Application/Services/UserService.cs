using System;
using System.Linq.Expressions;
using AutoMapper;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Repositories;
using ControlPannel.Infrastructure.Repositories;

namespace controlpannel.application.Services;

public class UserService
{
    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepo, IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }

 public async Task<List<User>> GetAllUsersAsync(Expression<Func<User, object>> sortBy, bool descending)
    {
        if (sortBy == null)
        {
            throw new ArgumentNullException(nameof(sortBy), "SortBy cannot be null.");
        }

        if (sortBy.Body is MemberExpression memberExpr)
        {
            string memberName = memberExpr.Member.Name;
            if (memberName != nameof(User.FirstName) && memberName != nameof(User.Email))
            {
                throw new ArgumentException("Invalid sorting field. Allowed fields: FirstName, Email.");
            }
        }
        else if (sortBy.Body is UnaryExpression unaryExpr && unaryExpr.Operand is MemberExpression operandMember)
        {
            string memberName = operandMember.Member.Name;
            if (memberName != nameof(User.FirstName) && memberName != nameof(User.Email))
            {
                throw new ArgumentException("Invalid sorting field. Allowed fields: FirstName, Email.");
            }
        }
        else
        {
            throw new ArgumentException("Invalid sorting expression.");
        }

        return await _userRepo.GetAllUsersAsync(sortBy, descending);
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        var user = await _userRepo.GetUserByEmailAsync(email);
        return user != null ? _mapper.Map<UserDto>(user) : null;
    }

    public async Task AddAsync(AddUserRequestDto dto)
    {
        var entity = _mapper.Map<User>(dto);
        await _userRepo.AddUserAsync(entity);
    }

    public async Task Update(UpdateUserRequestDto dto)
    {
        var enttiy = _mapper.Map<User>(dto);
        await _userRepo.UpdateUserAsync(entity);
    }

}
