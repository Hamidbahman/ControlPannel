using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Enums;




namespace ControlPannel.Domain.Repositories;
public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync(Expression<Func<User, object>> sortBy, bool descending);
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByIdAsync(long id);
    Task<User> GetUserByFirstNameAsync(string firstName);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task<bool> deleteUserAsync(long id);
}

