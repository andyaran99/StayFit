using StayFit.StayFit_Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace StayFit.StayFit_Data.Repositories;

public class ExerciceRepository:IRepoitory<Exercice>
{
    private readonly Context _context;

    public ExerciceRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Exercice>> GetAll()
    {
        return await _context.Exercices
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Exercice> Get(int id)
    {
        return await _context.Exercices
            .SingleAsync(user => user.Id == id);
    } 

    public async Task Delete(int id)
    {
        _context.Exercices.Remove(await Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Add(Exercice newExercice)
    {
        _context.Exercices.Add(newExercice);
        await _context.SaveChangesAsync();
    }

    public async Task<Exercice> Update(Exercice updatedExercice)
    {
        Exercice exercice = await _context.Exercices.SingleAsync(exercice => exercice.Id == updatedExercice.Id);
        exercice.Name = updatedExercice.Name;
        exercice.Description = updatedExercice.Description;
        exercice.DateTime = updatedExercice.DateTime;
        
        
        await _context.SaveChangesAsync();
        return exercice;
    }
}