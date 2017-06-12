using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DealCoin.Authentication;
using DealCoin.Services;
using DealCoin.DAL;
using DealCoin.Models;

namespace DealCoin.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class UserController : Controller
    {
        readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public IActionResult GetUser(string email)
        {
            Result<User> result = _userService.getUser(email);
            return new JsonResult(result);
        }
        [HttpGet("Id/{id}")]
        public IActionResult GetUser(int id)
        {
            Result<User> result = _userService.getUserId(id);
            return new JsonResult(result);
        }
        [HttpGet("All/")]
        public IActionResult GetAllUser()
        {
            Result<IEnumerable <User>>  result = _userService.getAllUser();
            return new JsonResult(result);
        }
        [HttpPost("UserAdmin/{model}")]
        public bool CreatUserAdmin([FromBody] UserViewModel _model )
        {
            _userService.CreatePasswordUser(_model.email,_model.password);
            return (true);
        }

        [HttpPut("{model}")]
        public IActionResult UpdateUser([FromBody] UserViewModel _model)
        {
            Result<IEnumerable<User>> result = _userService.UpdateUser(_model.userId, _model.nom, _model.prenom, _model.phone,
            _model.addresse, _model.departement, _model.city, _model.postale);
            return new JsonResult(result);
        }
        [HttpDelete("{Id}")]
        public bool DeleteEvent(int Id)
        {
            _userService.DeleteUser(Id);
            return (true);
        }

        [HttpPut("UserPass/{model}")]
        public bool UpdateUserCode([FromBody] UserViewModel _model)
        {
            _userService.UpdateUserCode(_model.userId, _model.password);
            return (true);
        }
    }
}