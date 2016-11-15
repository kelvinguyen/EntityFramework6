using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlgorithm
{
    public class CustomStack<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Push(T value)
        {
            _list.AddFirst(value);
        }

        public T Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Empty List");
            T val = _list.First.Value;
            _list.RemoveFirst();
            return val;
        }

        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Empty List");
            return _list.First.Value;
        }
    }
}
