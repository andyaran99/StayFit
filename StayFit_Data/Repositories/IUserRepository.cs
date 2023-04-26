using StayFit.StayFit_Data.Entity;
namespace StayFit.StayFit_Data.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> Get(int id);
    Task<User> GetByUserName(string username);
    Task Delete(int id);
    Task Add(User entity);
    Task<User> Update(User entity);
}