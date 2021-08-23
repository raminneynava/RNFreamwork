using AdminEndpoint.Models;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Admins()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public async Task<IActionResult> GetAllUsers()
        {
            return new JsonResult((await _userManager.GetUsersInRoleAsync("User")).Select(p => new UsersListViewModel
            {
                Id = p.Id,
                UserName = p.UserName,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber
            }));
        }
        public async Task<IActionResult> GetAllAdmins()
        {
            return new JsonResult((await _userManager.GetUsersInRoleAsync("Admin")).Select(p => new UsersListViewModel
            {
                Id = p.Id,
                UserName = p.UserName,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber
            }));
        }
    }
}
