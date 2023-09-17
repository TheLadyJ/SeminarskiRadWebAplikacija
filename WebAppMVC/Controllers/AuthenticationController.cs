using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using NuGet.Protocol.Plugins;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{

    public class AuthenticationController : Controller
    {
        private readonly UserManager<Radnik> manager;
        private readonly SignInManager<Radnik> signInManager;

        public AuthenticationController(UserManager<Radnik> manager, SignInManager<Radnik> signInManager)
        {
            this.manager = manager;
            this.signInManager = signInManager;
        }

        #region registracija

        [HttpGet]
        public IActionResult RegisterAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel register)
        {
            var radnikPostoji = await manager.FindByNameAsync(register.KorisnickoIme);

            if (radnikPostoji != null)
            {
                ModelState.AddModelError(string.Empty, "Već postoji radnik sa unetim korisnickim imenom");
                return View();
            }

            Radnik radnik = new Radnik
            {
                KorisnickoIme = register.KorisnickoIme,
                UserName = register.KorisnickoIme,
                Lozinka = register.Lozinka,
                Ime = register.Ime,
                Prezime = register.Prezime,
            };

            var result = await manager.CreateAsync(radnik, register.Lozinka);

            if (!result.Succeeded)
            {

                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View();
            }

            return RedirectToAction("Login");

        }
        #endregion

        #region prijava

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await signInManager.PasswordSignInAsync(login.KorisnickoIme, login.Lozinka, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Pogrešni kredencijali!");
            return View();

        }

        #endregion

        #region odjava

        [HttpGet]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        #endregion

        #region zabranjen pristup

        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }
        #endregion
    }
}
