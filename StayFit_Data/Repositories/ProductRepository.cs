using StayFit.StayFit_Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace StayFit.StayFit_Data.Repositories;

public class ProductRepository:IRepository<Product>
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Product> Get(int id)
    {
        return await _context.Products
            .SingleAsync(user => user.Id == id);
    } 

    public async Task Delete(int id)
    {
        _context.Products.Remove(await Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Add(Product item)
    {
        _context.Products.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> Update(Product updatedProduct)
    {
        _context.Products.Update(updatedProduct);
        await _context.SaveChangesAsync();
        return updatedProduct;
    }
}