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
            Services.Result<User> result = _userService.getUser(email);
            return new JsonResult(result);
        }

        [HttpPut("{model}")]
        public IActionResult UpdateUser([FromBody] UserViewModel _model)
        {
            Result<IEnumerable<User>> result = _userService.UpdateUser(_model.userId,_model.nom, _model.prenom, _model.phone,
                _model.addresse, _model.departement, _model.city, _model.postale);
            return new JsonResult(result);
        }

    }
}