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
        
        [HttpPost]
        public ActionResult Create(User user)
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

        
        [HttpPost]
        public ActionResult Update(string id, User user)
        {
            try
            {
                _userService.Update(id, user);
            }
            catch (Exception ex)
            {
                Result.SetException(ex);
            }

            return Json(Result);
        }
        
        [HttpPost]
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
        
        [HttpGet]        
        public ActionResult Get(string id)
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
       
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                Result.Items.AddRange(_userService.Get());
            }
            catch (Exception ex)
            {
                Result.SetException(ex);
            }

            return Json(Result);
        }
    }
}