using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class RoutineRepository:IRepoitory<Routine>
{
    private readonly Context _context;

    public RoutineRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Routine>> GetAll()
    {
        return await _context.Routines
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Routine> Get(int id)
    {
        return await _context.Routines
            .SingleAsync(user => user.Id == id);
    } 

    public async Task Delete(int id)
    {
        _context.Routines.Remove(await Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Add(Routine item)
    {
        _context.Routines.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Routine> Update(Routine updatedRoutine)
    {
        _context.Routines.Update(updatedRoutine);
        await _context.SaveChangesAsync();
        return updatedRoutine;
    }
}