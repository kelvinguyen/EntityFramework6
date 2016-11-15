using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlgorithm
{
    public class CSharpStack
    {
        public void Run()
        {
            Stack<int> mystack = new Stack<int>();
            mystack.Push(2);
            mystack.Pop();
            mystack.Peek();
        }
    }
}
