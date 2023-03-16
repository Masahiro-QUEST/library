//using System;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Authorization;

//namespace BlazorDemo.Data
//{
//    private readonly UserManager<ApplicationUser> _userManager;
//    [HttpPost]
//    [Authorize]
//    public async Task<IActionResult> StartSession()
//    {
//        var curUser = await _userManager.GetUserAsync(HttpContext.User);
//    }
//}

