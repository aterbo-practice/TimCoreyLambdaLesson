using System;
using System.Collections.Generic;
using System.Linq;
using TImCoreyLambdaLesson.Models;

namespace TImCoreyLambdaLesson
{
    class Program
    {
        private static List<ContactModel> data;

        static void Main(string[] args)
        {
            data = SampleData.GetContactData();

            LambdaTestWhere();
            LambdaTestSelect();
            LambdaTestTake();
            LambdaTestSkipTake();

            Console.WriteLine("Done Processing!");
            Console.ReadLine();
        }

        private static void LambdaTestWhere()
        {
            Console.WriteLine("Test - Where");

            var results = data.Where(x => x.Addresses.Count > 1);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine("End Test - Where \n");
        }

        private static void LambdaTestSelect()
        {
            Console.WriteLine("Test - Select");

            //Select outputs Ienumerable<string>
            //Note this trims down the input type, ContactModel, and outputs
            //A new object, just a list of strings
            var results = data.Select(x => x.FirstName);

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("End Test - Select \n");
        }

        private static void LambdaTestTake()
        {
            Console.WriteLine("Test - Take");

            //Take doesn't need a Func, just an int.
            //How many items do you want? Returns IEnumerable<ContactModel>
            var results = data.Take(2);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine("End Test - Take  \n");
        }

        private static void LambdaTestSkipTake()
        {
            Console.WriteLine("Test - Skip and Take");

            //Notice you can chain linq calls
            var results = data.Skip(2).Take(2);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine("End Test - Skip and Take  \n");
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
