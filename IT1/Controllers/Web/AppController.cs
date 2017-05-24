using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IT1.Models;
using IT1.Services;
using Microsoft.Extensions.Configuration;

namespace IT1.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IIT1Repository _repository;

        public AppController(IMailService mailService, IConfigurationRoot config, IIT1Repository repository)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {

            var data = _repository.GetAllExperiences();

            return View(data);
        }

        public IActionResult Skills()
        {
            return View();
        }

        public IActionResult Experience()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)
        {
            if (cvm.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("Email", "AOL addresses are toilet!!");
            }
            else
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], cvm.Name, "From IT1", cvm.Message);

                ModelState.Clear();

                ViewBag.UserMessage = "Message Sent";
            }

            return View();
        }
    }
}