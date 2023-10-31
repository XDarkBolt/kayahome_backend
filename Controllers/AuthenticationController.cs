using kayahome_backend.Contexts;
using kayahome_backend.Contexts.Dto;
using kayahome_backend.Contexts.Sets;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace kayahome_backend.Controllers
{
    public class AuthenticationController : BaseController
    {
        [Route("login")]
        [HttpGet]
        public IActionResult Login([FromQuery]LoginDto model)
        {
            KayaHomeContext kayahomeContext = new KayaHomeContext();
            Users kayahomeUsers = new Users();

            try
            {
                var loginUser = kayahomeContext.Users.Where(x => x.UserId == model.UserId && x.Password == model.Password)
                .Select(x => new {
                    Email = x.Email,
                    Name = x.Name,
                    SurName = x.SurName
                }).First();

                if (loginUser != null)
                {
                    return CreatedAtRoute(201, loginUser);
                }
                else
                {
                    return BadRequest("There is no user!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Data);
            }
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(UsersDto model)
        {
            try
            {
                KayaHomeContext kayahomeContext = new KayaHomeContext();

                Users kayahomeUsers = new Users();

                LoginDto login_model = new LoginDto();

                kayahomeUsers.Name = model.Name;
                kayahomeUsers.SurName = model.SurName;
                kayahomeUsers.UserId = model.UserId;
                kayahomeUsers.Password = model.Password;
                kayahomeUsers.Email = model.Email;
                kayahomeUsers.PhoneCountry = model.PhoneCountry;
                kayahomeUsers.PhoneNumber = model.PhoneNumber;
                kayahomeUsers.AddDate = DateTime.Now;
                kayahomeUsers.UpdateDate = DateTime.Now;
                kayahomeUsers.IsDeleted = false;

                kayahomeContext.Add(kayahomeUsers);
                kayahomeContext.SaveChanges();

                login_model.UserId = model.UserId;
                login_model.Password = model.Password;

                return RedirectToAction("Login", routeValues: login_model);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
