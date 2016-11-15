using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAlgorithm
{
    public class CustomLinkedList<T>
    {
        public Node<T> RootNode { get; set; }
        public Node<T> TailNode { get; set; }
        public int Count { get; set; }

        public bool AddNode(T value)
        {
            if (RootNode == null)
            {
                Node<T> newNode = new Node<T> { Value = value };
                RootNode = newNode;
                TailNode = newNode;
                Count++;
            }
            else
            {
                TailNode.Next = new Node<T> { Value = value };
                TailNode = TailNode.Next;
            }
            return true;
        }

        public void PrintCustomLinkedList()
        {
            Node<T> displayNode = RootNode;
            if (RootNode != null)
            {
                while (displayNode.Next != null)
                {
                    Console.Write(displayNode.Value + "-->");
                    displayNode = displayNode.Next;
                }
                Console.Write(displayNode.Value + "-->");
            }
            else
            {
                Console.WriteLine("The list is empty");
            }
            Console.WriteLine();
        }
        public void PrintNode(Node<T> node)
        {
            if(node == null)
                Console.WriteLine("Empty node");
            while (node != null)
            {
                Console.Write(node.Value + "-->");
                node = node.Next;
            }
            Console.WriteLine();
        }
    }
}
