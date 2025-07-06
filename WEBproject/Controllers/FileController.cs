public class FileController : Controller
{
    private readonly ApplicationDbContext _context;

    public FileController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult ManageFile(int? id)
    {
        var file = id.HasValue ? _context.Files.Find(id) : new File();
        return View(file);
    }

    [HttpPost]
    public IActionResult SaveFile(File file)
    {
        if (file.Id == 0)
        {
            _context.Files.Add(file);
        }
        else
        {
            _context.Files.Update(file);
        }
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}