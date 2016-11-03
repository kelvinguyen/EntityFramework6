using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.MainConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Given a list of ints whose values are 1 - 100, determine which numbers (1 - 100) are not in the list
            //(1,2,..5,7) 
            // List 1,9,10, 99
            //input: 1,2,3,4,5,6,7,8,9
            
            //output: 10
           
            
            //input: 1,3,5,7,9
           
            //output: 2,4,6,8,10
        }


        public static List<int> GetNumberNotInTheList(List<int> inputNumList)
        {

            List<int> defaultList = Enumerable.Range(1, 100).ToList();


            List<int> result = defaultList.Except(inputNumList).ToList();

            // 3 thing  : patient , medication,  prescription
            /**
             *  patient is person
             *  patient may/maynot has  1/ many medication
             *  patien may/maynot has 1/many prescription
             *  
             *  list patient with all the medication
             *  
             *  
             *  select p.name , m.medication from patient p
             *  join medicationJoinTable j
             *  on p.id == j.patientId
             *  join medication m
             *  on m.id == j.id
             *  
             */ 


            return result;
        }
      
    }
}
