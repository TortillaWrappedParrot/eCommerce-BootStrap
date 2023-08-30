using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eCommerceSite.Controllers
{
    public class MembersController : Controller
    {
        private readonly VideoGameContext _context;

        public MembersController(VideoGameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel) 
        {
            if (ModelState.IsValid)
            {
                //Map RegisterViewModel to member
                Member newMember = new()
                {
                    Email = regModel.Email,
                    Password = regModel.Password
                };

                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                //Log user in after creating an account
                LogUserIn(newMember.Email);
                return RedirectToAction("Index", "Home");
            }

            return View(regModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                //Check for record
                Member? meb = (from member in _context.Members
                               where member.Email == loginModel.Email &&
                                     member.Password == loginModel.Password
                               select member).SingleOrDefault();
                if (meb != null)
                {
                    LogUserIn(loginModel.Email);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(String.Empty, "Credentials not found");
            }
            //Return if no login or model isn't valid
            return View(loginModel);
        }

        //Set session email to provided email
        private void LogUserIn(string email)
        {
            HttpContext.Session.SetString("Email", email);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            //Clear session and return to home page
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
