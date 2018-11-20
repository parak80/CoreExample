using CoreExample.Services;
using CoreExample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreExample.Controllers
{
	public class AppController : Controller
	{
		private readonly IMailService _MailService;

		public AppController(IMailService mailService) //to inject the services we need we make constructor here after doing the setup services
		{
			//to be able to save it for the method
			_MailService = mailService;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet("contact")]
		public IActionResult Contact()
		{
			return View();
		}
		[HttpPost("contact")]
		public IActionResult Contact(ContactViewModel model)
		{
			if (ModelState.IsValid)
			{
				//send the email
				//for that this service works here should first add the service in setup
				_MailService.SendMessage ("shawn@wildermuth.com", model.Subject, $"Form: {model.Name} - {model.Email}, Message: {model.Message}");
				//show the email
				ViewBag.UserMessage = "Mail Sent";
				ModelState.Clear();  //so when the message sent empty all input fields
			}
			return View();
		}
		public IActionResult About()
		{
			ViewBag.Title = "About Us";
			return View();
		}
	}
}
