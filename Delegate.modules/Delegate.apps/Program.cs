using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegate.DllExample1;
using Event.dllExample;
using EventHandler.dllExample;


namespace Delegate.apps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // delegate example
            DelegateExample myDelegate = new DelegateExample();
            myDelegate.WireUpTheDelegateToHandler(1, "This data is send to real handler 1 and 2");

            // event example
            MyHandlerObject objectHandleEvent = new MyHandlerObject();
            objectHandleEvent.wireEventToEventHandler(1,"data send");
        }
    }
}
