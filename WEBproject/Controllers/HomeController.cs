using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WEBproject.Models;

namespace WEBproject.Controllers;

 public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var files = _context.Files
            .Include(f => f.User)
            .Where(f => f.IsPublic)
            .OrderByDescending(f => f.DateUpdated)
            .ToList();

        ViewBag.UserCount = _context.Users.Count();
        ViewBag.FileCount = _context.Files.Count();

        return View(files);
    }
}