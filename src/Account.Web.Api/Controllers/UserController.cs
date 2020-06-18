using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Application.Core.Entity;
using Account.Application.Core.Interface.Service;
using Account.Web.Api.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public Result<User> Result { get; set; }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost("Create")]
        public ActionResult Create([FromBody] User user)
        {
            try
            {
                _userService.Create(user); 
            }
            catch(Exception ex)
            {
                Result.SetException(ex);
            }

            return Json(Result);
        }

        
        [HttpPost("Update")]
        public ActionResult Update ([FromBody]User user)
        {
            try
            {
                _userService.Update(user);
            }
            catch (Exception ex)
            {
                Result.SetException(ex);
            }

            return Json(Result);
        }
        
        [HttpDelete("Remove/{id}")]
        public ActionResult Remove(string id)
        {
            try
            {
                _userService.Remove(id);
            }
            catch (Exception ex)
            {
                Result.SetException(ex);
            }

            return Json(Result);
        }
        
        [HttpGet("GetById/{id}")]        
        public ActionResult GetById(string id)
        {
            try
            {
                Result.Items.Add(_userService.Get(id));
            }
            catch (Exception ex)
            {
                Result.SetException(ex);
            }

            return Json(Result);
        }
       
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            try
            {
                var users = _userService.Get();

                if(users!= null)
                {
                    Result.Items.AddRange(_userService.Get());
                }
                
            }
            catch (Exception ex)
            {
                Result.SetException(ex);
            }

            return Json(Result);
        }
    }
}