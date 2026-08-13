using Microsoft.AspNetCore.Mvc;
using SmartWarehouse.DataAccess;

namespace SmartWarehouse.Controllers
{
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
            return Content ("Kullanıcı adı: " + username + " | Şifre: " + password);
        }
    }
}