using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IT1.Controllers.Web
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}