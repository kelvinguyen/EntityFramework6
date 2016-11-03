using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalyst.MainConsole;
using System.Collections.Generic;
using System.Linq;

namespace Catalyst.GetNumberNotInListTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<int> inputList = new List<int> { 6, 5, 99 };


            List<int> resultList = Program.GetNumberNotInTheList(inputList);

            foreach (var num in resultList)
            {
                Console.WriteLine(num);
            }
        }

        //public void TestMethod2()
        //{

        //    List<int> defaultList = Enumerable.Range(1, 101).ToList();

        //    foreach(var num in defaultList)

        //}
    }
}
