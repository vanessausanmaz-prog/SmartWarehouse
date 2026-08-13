using Microsoft.AspNetCore.Mvc;
using SmartWarehouse.Business.Interfaces;

namespace SmartWarehouse.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userService.GetByUsernameAsync(username);

            if (user == null || user.Password != password)
        {
                return Content("Kullanıcı adı veya şifre hatalı.");
        }
            return Content("Giriş başarılı. Hoş geldin " + user.Username);
        }
    }
}