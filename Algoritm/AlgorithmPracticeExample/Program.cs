using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPracticeExample
{
    //https://coderbyte.com/profile/kelvinguyen
    public class Program
    {
        public static void Main(string[] args)
        {
            var result = Program.ReverseUsingXor("this is my string");

            Console.WriteLine($"The result is {result}");

            Console.WriteLine(LetterChanges("hello*3"));
        }

      

        public static string ReverseUsingXor(string str)
        {
            var arr = str.ToCharArray();
            int len = str.Length - 1;
            int count = 0;
            Console.WriteLine($"the length is {len}");
            for (int i = 0; i < len; i++, len--)
            {
                arr[i] ^= arr[len];
                arr[len] ^= arr[i];
                arr[i] ^= arr[len];
              
                count++;
            }
            Console.WriteLine($"the count is {count}");
            return new string(arr);
        }

        public static string LetterChanges(string str)
        {

            // code goes here  
            /* Note: In C# the return type of a function and the 
               parameter types being passed are defined, so this return 
               call must match the return type of the function.
               You are free to modify the return type. */
            var arr = str.ToCharArray();
            char[] temparr = { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i] == 'z'))
                {
                    arr[i] = 'a';
                }
                else if (arr[i] == 'Z')
                {
                    arr[i] = 'A';
                }
                else if (!char.IsLetter(arr[i]))
                {
                    continue;
                }
                else
                {
                    arr[i] = (char)(arr[i] + 1);
                    if (temparr.Contains(arr[i]))
                    {
                        arr[i] =char.ToUpper(arr[i]);
                    }
                }

            }

            return new string(arr);

        }
    }
}
