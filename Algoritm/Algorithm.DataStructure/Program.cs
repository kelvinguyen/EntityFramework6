using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListAlgorithm;

namespace Algorithm.DataStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
        //    CustomLinkedList<int> list = new CustomLinkedList<int>();
        //    list.AddNode(3);
        //    list.AddNode(5);
        //    list.AddNode(7);
        //    list.PrintCustomLinkedList();
        //    list.PrintNode(list.RootNode);


            Console.WriteLine(Program.Test("hello"));
        }

        public static string Test(string str)
        {
            return string.Concat(str.OrderBy(x => x));
        }
    }
}
