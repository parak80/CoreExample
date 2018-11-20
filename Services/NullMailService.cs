using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreExample.Services
{
    public class NullMailService : IMailService  //after all done in this page should go on the class NullMailService ctrl . and hit Extract interface which create a class
	{
		private readonly ILogger<NullMailService> _logger;

		//this contructor (ctor) injects logger into our class, so we can use the login information later
		public NullMailService(ILogger<NullMailService> logger) //after this we create a field by goin on word logger and ctrl . create field..
		{
			_logger = logger;
		}

		public void SendMessage(string to, string subject, string body)
		{
			//Log the message but not sending it
			_logger.LogInformation($"To:{to} Subject: {subject} Body: {body}");
		}
    }
}
