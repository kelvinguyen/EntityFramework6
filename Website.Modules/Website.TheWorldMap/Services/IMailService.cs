using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.TheWorldMap.Services
{
    public interface IMailService
    {
        void SendMessage(string from, string to, string subject, string body);
        
    }
}
