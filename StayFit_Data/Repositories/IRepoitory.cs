namespace StayFit.StayFit_Data.Repositories;

public interface IRepoitory<T>
{
    Task<List<T>> GetAll();
    Task<T> Get(int id);
    Task Delete(int id);
    Task Add(T entity);
    Task<T> Update(T entity);
}