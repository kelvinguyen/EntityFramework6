using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.dllExample;
using Delegate.DllExample1;

namespace EventHandler.dllExample
{
    public class MyHandlerObject
    {

        public void RealHandler1(int x, string y)
        {
            // this real handler is wire up when instatiate delegate instance
            Console.WriteLine("I'm a real handler 1");
        }

        public void RealHandler2(int x, string y)
        {
            // this real handler is wire up when instatiate delegate instance
            Console.WriteLine("I'm a real handler 2");
        }


        public void wireEventToEventHandler(int data, string name)
        {
            ObjectContainEvent objectHasEvent = new ObjectContainEvent();



            //one way: fully write out
            objectHasEvent.eventIsJustToNotifyTheirObject 
                += new DelegateHoldBlueprintToHandler(RealHandler1);
            // delegate inference : sugar code
            objectHasEvent.eventIsJustToNotifyTheirObject += RealHandler2;



            objectHasEvent.raiseEventToDelegateAndAskRealHandlerToDoWork(data, name);

        }
    }
}
