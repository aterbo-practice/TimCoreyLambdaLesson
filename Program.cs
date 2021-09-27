using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TImCoreyLambdaLesson.Models;

namespace TImCoreyLambdaLesson
{
    class Program
    {
        private static List<ContactModel> data;

        static void Main(string[] args)
        {
            data = SampleData.GetContactData();

            //Lambda Tests:
            Where();
            Select();
            Take();
            SkipTake();
            OrderByAscending();
            OrderByDescending();

            Console.WriteLine("Done Processing!");
            Console.ReadLine();
        }

        private static void Where()
        {
            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            var results = data.Where(x => x.Addresses.Count > 1);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }



        private static void Select()
        {
            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            //Select outputs Ienumerable<string>
            //Note this trims down the input type, ContactModel, and outputs
            //A new object, just a list of strings
            var results = data.Select(x => x.FirstName);

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }



        private static void Take()
        {
            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            //Take doesn't need a Func, just an int.
            //How many items do you want? Returns IEnumerable<ContactModel>
            var results = data.Take(2);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }



        private static void SkipTake()
        {
            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            //Notice you can chain linq calls
            var results = data.Skip(2).Take(2);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }

        private static void OrderByAscending()
        {

            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            //Takes a Func
            var results = data.OrderBy(x => x.FirstName);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }

        private static void OrderByDescending()
        {

            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            //Takes a Func
            var results = data.OrderByDescending(x => x.FirstName);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }










        //Below is the explaination of the Lambda syntax

        //This is the same method written out as the predicate above
        //Where(x => x.Addresses.Count > 1)
        private static bool RunMeWrittenOut(ContactModel x)
        {
            if (x.Addresses.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Shortened version, same logic
        //Where(x => x.Addresses.Count > 1)
        private static bool RunMe(ContactModel x)
        {
            return x.Addresses.Count > 1;
        }

        //Microsoft .NET does the following simplifications/assumptions:
        //1. Eliminate private and static.
        //      bool RunMe(ContactModel x) { return x.Addresses.Count > 1; }
        //2. Knows the Func input in .Where needs a boolean return
        //      RunMe(ContactModel x) { return x.Addresses.Count > 1; }
        //3. Funtion is being called immediately, so don't need the name
        //      (ContactModel x) { return x.Addresses.Count > 1; }
        //4. Knows that the call is for a ContactModel (data.Where)
        //      (x) { return x.Addresses.Count > 1; }
        //5. Know there's only one line of code, must be the return logic
        //      (x) { x.Addresses.Count > 1; }
        //6. Need a seperator symbol, use =>
        //      x => x.Addresses.Count > 1


    }
}
