using StayFit.StayFit_Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace StayFit.StayFit_Data.Repositories;

public class NewsMessageRepository:IRepository<NewsMessage>
{
    private readonly Context _context;

    public NewsMessageRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<NewsMessage>> GetAll()
    {
        return await _context.NewsMessages
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<NewsMessage> Get(int id)
    {
        return await _context.NewsMessages
            .SingleAsync(user => user.Id == id);
    } 

    public async Task Delete(int id)
    {
        _context.NewsMessages.Remove(await Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Add(NewsMessage item)
    {
        _context.NewsMessages.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<NewsMessage> Update(NewsMessage updatedNewsMessage)
    {
        _context.NewsMessages.Update(updatedNewsMessage);
        await _context.SaveChangesAsync();
        return updatedNewsMessage;
    }
}