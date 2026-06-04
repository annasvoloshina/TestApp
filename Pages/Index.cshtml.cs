using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db)
    {
        _db = db;
    }

    public IList<Product> Products { get; private set; } = new List<Product>();

    public async Task OnGetAsync()
    {
        Products = await _db.Products.OrderBy(p => p.Id).ToListAsync();
    }
}
