using StayFit.StayFit_Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace StayFit.StayFit_Data.Repositories;

public class DetailsRepository:IRepoitory<Details>
{
    private readonly Context _context;

    public DetailsRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Details>> GetAll()
    {
        return await _context.Details
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Details> Get(int id)
    {
        return await _context.Details
            .SingleAsync(user => user.Id == id);
    } 

    public async Task Delete(int id)
    {
        _context.Details.Remove(await Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Add(Details newDetails)
    {
        _context.Details.Add(newDetails);
        await _context.SaveChangesAsync();
    }

    public async Task<Details> Update(Details updatedDetails)
    {
        Details details = await _context.Details.SingleAsync(details => details.Id == updatedDetails.Id);
        details.BodyType = updatedDetails.BodyType;
        details.RoutineType = updatedDetails.RoutineType;
        details.DateTime = updatedDetails.DateTime;
        
        await _context.SaveChangesAsync();
        return details;
    }
    
}