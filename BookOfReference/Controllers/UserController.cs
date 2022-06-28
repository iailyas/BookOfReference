using BookOfReference.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookOfReference.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDBContext context;

        public UserController(ApplicationDBContext context)
        {
            this.context = context;
        }


        [HttpPost("/Login")]

        public async Task<LoginModel> Login(LoginModel model)
        {

            User user = await context.User.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                await Authenticate(model.Email); // аутентификация


            }


            return model;
        }

        [HttpPost("/Register")]

        public async Task<RegistrationModel> Register(RegistrationModel model)
        {

            User user = await context.User.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                // добавляем пользователя в бд
                context.User.Add(new User { Email = model.Email, Password = model.Password });
                await context.SaveChangesAsync();

                await Authenticate(model.Email); // аутентификация


            }



            return model;
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        [HttpGet]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
           
        }
    }
}

