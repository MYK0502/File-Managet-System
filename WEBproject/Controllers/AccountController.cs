public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            // Set session or authentication cookie
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Error = "Username or password is incorrect.";
            return View();
        }
    }
}