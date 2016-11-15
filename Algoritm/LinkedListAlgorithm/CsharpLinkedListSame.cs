using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithm
{
    public class CsharpLinkedListSame
    {

        public void Run()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(3);
            list.AddFirst(4);
            list.AddBefore(new LinkedListNode<int>(2), 3);
            
        }
    }
}
