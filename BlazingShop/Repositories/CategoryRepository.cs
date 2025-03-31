using BlazingShop.Data;
using BlazingShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Repositories;

public class CategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Category>> GetCategoriesAsync() => 
        await _context.Categories.AsNoTracking().ToListAsync();
}