using Microsoft.EntityFrameworkCore;
using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Repositories.Repositories;


public class UserRepository:IUserRepository
{
    private readonly Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll() => await _context.Users.AsNoTracking().ToListAsync();

    public async Task<User> Get(int id) => await _context.Users.FirstAsync(user => user.Id == id);

    public async Task Delete(int id)
    {
        _context.Users.Remove(await Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Add(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> Update(User entity)
    {
        var userToUpdate = await _context.Users.SingleAsync(u => u.Id == entity.Id);
        userToUpdate.HashedPassword = entity.HashedPassword;
        userToUpdate.FirstName = entity.FirstName;
        userToUpdate.LastName = entity.LastName;
        userToUpdate.Email = entity.Email;
        userToUpdate.Payment = entity.Payment;
        userToUpdate.BodyType = entity.BodyType;
        userToUpdate.UserRole = entity.UserRole;
        await _context.SaveChangesAsync();
        return userToUpdate;
    }

    public async Task<User> GetByUserName(string username) => await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Username == username);
}