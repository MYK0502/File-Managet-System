public class UserController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult ManageUser(int? id)
    {
        var user = id.HasValue ? _context.Users.Find(id) : new User();
        return View(user);
    }

    [HttpPost]
    public IActionResult SaveUser(User user)
    {
        if (user.Id == 0)
        {
            _context.Users.Add(user);
        }
        else
        {
            _context.Users.Update(user);
        }
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}