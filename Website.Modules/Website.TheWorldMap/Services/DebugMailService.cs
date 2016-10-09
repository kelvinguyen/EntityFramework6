using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Website.TheWorldMap.Services
{
    public class DebugMailService : IMailService
    {
        public void SendMessage(string from, string to, string subject, string body)
        {
            Debug.WriteLine($"Sending Mail: To:{to} from:{from} subject:{subject}");
        }
    }
}
