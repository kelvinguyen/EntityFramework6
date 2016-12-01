using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomBinaryTree
{
    public class Node<T>
    {
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }

    }
    public class CustomBinaryTree<T>
    {
        public T RootNode { get; set; }

        public void Run(string str)
        {
            //Regex.Replace();
            /*
             * \d{1,5} : digit 1-5
             * \D : anything that is not a number
             * \s : space
             * \S : anything but not space
             * \w+ : 1 or charactor
             * \W : anything but character
             * \. : .
             * \b : Matches a word boundary, a word boundary is a position that separates a word character from a non-word character
             */
           // char[] arr = new char[4];
           
        }

    }
}
