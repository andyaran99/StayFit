using StayFit.StayFit_Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace StayFit.StayFit_Data.Repositories;

public class PaymentRepository
{
    private readonly Context _context;

    public PaymentRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Payment>> GetAll()
    {
        return await _context.Payments
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Payment> Get(int id)
    {
        return await _context.Payments
            .SingleAsync(user => user.Id == id);
    } 

    public async Task Delete(int id)
    {
        _context.Payments.Remove(await Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Add(Payment item)
    {
        _context.Payments.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Payment> Update(Payment updatedPayment)
    {
        _context.Payments.Update(updatedPayment);
        await _context.SaveChangesAsync();
        return updatedPayment;
    }
}