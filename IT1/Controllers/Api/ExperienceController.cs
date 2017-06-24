using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IT1.ViewModels;
using IT1.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IT1.Controllers.Api
{
    //[Produces("application/json")]
    [Route("api/Experiences")]
    public class ExperienceController : Controller
    {
        private IIT1Repository _repository;
        private UserManager<IT1User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        private ILogger<ExperienceController> _logger;

        public ExperienceController(IIT1Repository repository, UserManager<IT1User> userManager, IHttpContextAccessor httpContextAccessor, ILogger<ExperienceController> logger)
        {
            _repository = repository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [HttpGet("json")]
        public JsonResult Json()
        {
            return Json(new ExperienceViewModel() { Company = "My Json Company" });
        }

        //This is better because you can return other result codes such as 404 not found or 400 Bad Request
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            //if (true) return BadRequest("Bad things happen!!");

            return Ok(Mapper.Map<IEnumerable<ExperienceViewModel>>(_repository.GetExperiencesByUserId(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ExperienceViewModel experience)
        {
            if (ModelState.IsValid)
            {
                var newExperience = Mapper.Map<Experience>(experience);

                var user = await _userManager.GetUserAsync(HttpContext.User);

                var userId = user?.Id;

                //TODO Add to context to save to DB
                _repository.AddExperience(newExperience);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/Experience/{experience.Company}", Mapper.Map<ExperienceViewModel>(newExperience));
                }      
            }

            return BadRequest("Failed to save Experience");
            //Can be used for debugging purposes
            //return BadRequest(ModelState);
        }
    }
}