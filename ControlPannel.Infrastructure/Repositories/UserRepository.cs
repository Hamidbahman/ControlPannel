using System.Linq.Expressions;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Repositories;
using ControlPannel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlPannel.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SecurityDbContext _context;
    public UserRepository(SecurityDbContext context)
    {
        _context = context;
    }
    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> deleteUserAsync(long id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

public async Task<List<User>> GetAllUsersAsync(string sortBy, bool descending)
    {
        IQueryable<User> query = _context.Users;

        if (sortBy.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
        {
            query = descending ? query.OrderByDescending(u => u.FirstName) : query.OrderBy(u => u.FirstName);
        }
        else if (sortBy.Equals("Email", StringComparison.OrdinalIgnoreCase))
        {
            query = descending ? query.OrderByDescending(u => u.Email) : query.OrderBy(u => u.Email);
        }
        else
        {
            throw new ArgumentException("Invalid sorting field. Allowed fields: FirstName, Email.");
        }

        return await query.ToListAsync();
    }

    public Task<List<User>> GetAllUsersAsync(Expression<Func<User, object>> sortBy, bool descending)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        User user = 
        await _context.Users.FirstOrDefaultAsync(u=>u.Email == email);
        return user;
    }

    public async Task<User> GetUserByFirstNameAsync(string firstName)
    {
        User user = 
        await _context.Users.FirstOrDefaultAsync(u=>u.FirstName == firstName);
        return user;
    }

    public async Task<User> GetUserByIdAsync(long id)
    {
        User user =
            await _context.Users.FirstOrDefaultAsync(u=>u.Id == id);

        return user;
    }    

    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

}
