using BlazingShop.Data;
using BlazingShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Repositories;

public class ProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsAsync() => await _context
        .Products.AsNoTracking().ToListAsync();

    public async Task<Product?> GetProductByIdAsync(int id) => await _context.Products
        .AsNoTracking()
        .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Product?> GetProductWithCategoryByIdAsync(int id) => await _context.Products
        .AsNoTracking()
        .Include(p => p.Category)
        .FirstOrDefaultAsync(p => p.Id == id);

    public async Task UpdateAsync(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task SaveAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }
}