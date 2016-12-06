using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCore.CityApi.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = Startup.Configuration["mailSetting:mailToAddress"];
        private string _mailFrom = Startup.Configuration["mailSetting:mailFromAddress"];

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService");
            Debug.WriteLine($"Subject:{subject}");
            Debug.WriteLine($"Message : {message}");
        }
    }
}
