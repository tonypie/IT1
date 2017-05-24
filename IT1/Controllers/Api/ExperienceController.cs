using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IT1.ViewModels;

namespace IT1.Controllers.Api
{
    //[Produces("application/json")]
    [Route("api/Experience")]
    public class ExperienceController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(ExperienceViewModel model)
        {
            if(ModelState.IsValid)
            {
                return Created($"api/Experience/{model.Name}", model);
            }

            return BadRequest("Problemmmmmmmm!!");
        }
    }
}