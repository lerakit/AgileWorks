using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly DAL.EF.AppDbContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(DAL.EF.AppDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public IList<Request> Requests { get;set; } = default!;

    public void OnGet()
    {
        Requests = _context.Requests.Where(r => r.Finished == false)
            .OrderByDescending(r => r.Deadline)
            .ToList();
    }
    public async Task<IActionResult> OnPostMarkAsFinished(int id)
    {
        var request = await _context.Requests.FindAsync(id);
        if (request != null)
        {
            request.Finished = true;
            await _context.SaveChangesAsync();
        }

        return RedirectToPage(); 
    }
}