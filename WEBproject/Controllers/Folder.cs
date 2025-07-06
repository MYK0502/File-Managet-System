public class FolderController : Controller
{
    private readonly ApplicationDbContext _context;

    public FolderController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult ManageFolder(int? id)
    {
        var folder = id.HasValue ? _context.Folders.Find(id) : new Folder();
        return View(folder);
    }

    [HttpPost]
    public IActionResult SaveFolder(Folder folder)
    {
        if (folder.Id == 0)
        {
            _context.Folders.Add(folder);
        }
        else
        {
            _context.Folders.Update(folder);
        }
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}