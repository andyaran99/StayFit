using Microsoft.EntityFrameworkCore;
using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Repositories.Repositories;


public class UserRepository:IRepository<User>
{
    private readonly Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        return await _context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User> Get(int id)
    {
        return await _context.Users
            .SingleAsync(user => user.Id == id);
    } 

    public async Task Delete(int id)
    {
        _context.Users.Remove(await Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Add(User item)
    {
        _context.Users.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<User> Update(User updatedUser)
    {
        _context.Users.Update(updatedUser);
        await _context.SaveChangesAsync();
        return updatedUser;
    }
}