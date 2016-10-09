using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.TheWorldMap.ViewModels;
using Website.TheWorldMap.Services;
using Microsoft.Extensions.Configuration;
using Website.TheWorldMap.Models;
using Microsoft.Extensions.Logging;

namespace Website.TheWorldMap.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IWorldRepository _repo;
        private ILogger<AppController> _logger;

        public AppController(IMailService mailService,
                             IConfigurationRoot config,
                             IWorldRepository repo,
                             ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repo = repo;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {

                var data = _repo.GetAllTrips();
                return View(data);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Fail to get all trip {ex.Message}");
                return Redirect("/error");
            }
        }

        public IActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("@aol.com"))
            {
                ModelState.AddModelError("", "we don't supprt aol");
                ModelState.AddModelError("Mail", "we don't supprt aol");
            }
                
            if (ModelState.IsValid)
            {
                _mailService.SendMessage(_config["MailSetting:ToAddress"],
                                     model.Email,
                                     model.Name,
                                     model.Message);
                ModelState.Clear();
                ViewBag.UserMessage = "Message Sent";
            }
            
            return View();
        }

        public IActionResult About()
        {

            return View();
        }
    }
}
