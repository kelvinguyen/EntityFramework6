using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegate.DllExample1;

namespace Event.dllExample
{
    
    public class ObjectContainEvent
    {
        public event DelegateHoldBlueprintToHandler eventIsJustToNotifyTheirObject;

        
        public void raiseEventToDelegateAndAskRealHandlerToDoWork(int data, string name)
        {
            // one way - raising event directly
            if (eventIsJustToNotifyTheirObject != null)
            {
                eventIsJustToNotifyTheirObject(data, name);
            }

            // other way - raising event by delegate
            DelegateHoldBlueprintToHandler getDelegateFromEvent
                = eventIsJustToNotifyTheirObject as DelegateHoldBlueprintToHandler;
            if (getDelegateFromEvent != null)
            {
                getDelegateFromEvent(data, name);
            }
        }
    }
}
