using System;
using System.Linq;
using TImCoreyLambdaLesson.Models;

namespace TImCoreyLambdaLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Done Processing!");
            Console.ReadLine();
        }

        private static void LambdaTest()
        {
            var data = SampleData.GetContactData();

            var results = data.Where(x => x.Addresses.Count > 1);
        }

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
