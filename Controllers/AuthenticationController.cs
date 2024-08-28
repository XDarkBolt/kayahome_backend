using kayahome_backend.Contexts;
using kayahome_backend.Contexts.Dto;
using kayahome_backend.Contexts.Sets;
using kayahome_backend.Models;
using kayahome_backend.Functions;
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
        public IActionResult Login([FromQuery] LoginDto model)
        {
            KayaHomeContext kayahomeContext = new KayaHomeContext();
            Users kayahomeUsers = new Users();

            try
            {
                var loginUser = kayahomeContext.Users.Where(x => x.UserId == model.UserId && x.Password == model.Password)
                .Select(x => new
                {
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
                LogWriter.LogWrite(ex.Message); ////////////////////////////////////////////////////////////////////
                return BadRequest(ex.Message);
            }
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(UsersDto usersDto)
        {
            try
            {
                KayaHomeContext kayahomeContext = new KayaHomeContext();

                Users kayahomeUsers = new Users();

                LoginModel login_model = new LoginModel();

                kayahomeUsers.Name = usersDto.Name;
                kayahomeUsers.SurName = usersDto.SurName;
                kayahomeUsers.UserId = usersDto.UserId;
                kayahomeUsers.Password = usersDto.Password;
                kayahomeUsers.Email = usersDto.Email;
                kayahomeUsers.PhoneCountry = usersDto.PhoneCountry;
                kayahomeUsers.PhoneNumber = usersDto.PhoneNumber;
                kayahomeUsers.AddDate = DateTime.Now;
                kayahomeUsers.UpdateDate = DateTime.Now;
                kayahomeUsers.IsDeleted = false;

                kayahomeContext.Add(kayahomeUsers);
                kayahomeContext.SaveChanges();

                login_model.UserId = usersDto.UserId;
                login_model.Password = usersDto.Password;

                return RedirectToAction("Login", routeValues: login_model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
