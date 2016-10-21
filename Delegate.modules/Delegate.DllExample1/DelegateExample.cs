using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.DllExample1
{

    public delegate void DelegateHoldBlueprintToHandler(int data, string dataName);

    /**
     * To use the delegate, 
     *  -you just need to call WireUpTheDelegateToHandler method
     */
    public class DelegateExample
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



        public void WireUpTheDelegateToHandler(int data , string  dataName)
        {
            DelegateHoldBlueprintToHandler delegateInstance1 
                = new DelegateHoldBlueprintToHandler(RealHandler1);

            DelegateHoldBlueprintToHandler delegateInstance2 = RealHandler2; // sugar code

            delegateInstance1 += delegateInstance2; // multicast to invocation list

            delegateInstance1.Invoke(data, dataName);
        }
    }
}
