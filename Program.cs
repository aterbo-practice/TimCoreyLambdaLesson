using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TImCoreyLambdaLesson.Models;

namespace TImCoreyLambdaLesson
{
    class Program
    {
        private static List<ContactModel> contacts;
        private static List<AddressModel> addresses;

        static void Main(string[] args)
        {
            contacts = SampleData.GetContactData();
            addresses = SampleData.GetAddressData();

            //Lambda Tests:
            /*
            Where();
            Select();
            Take();
            SkipTake();
            OrderByAscending();
            OrderByDescending();
            */

            //Linq Test:
            WhereSelect();
            JoinSelect();
            SelectWhereTwoSources();
            SelectWhereManyToMany();

            Console.WriteLine("Done Processing!");
            Console.ReadLine();
        }


        #region LambdaTests
        //Lambda tests
        //Simple examples of Lambda syntax
        private static void Where()
        {
            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            var results = contacts.Where(x => x.Addresses.Count > 1);

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
            var results = contacts.Select(x => x.FirstName);

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
            var results = contacts.Take(2);

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
            var results = contacts.Skip(2).Take(2);

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
            var results = contacts.OrderBy(x => x.FirstName);

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
            var results = contacts.OrderByDescending(x => x.FirstName);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }
        #endregion LambdaTests



        #region LinqTests
        //Here are more complicated examples of SQL-like LINQ query syntax
        //These queries are used for more complicated queries or if you want more
        //control over specifying the data return type, anonymous class, other
        //objects created on the fly, etc.

        private static void WhereSelect()
        {

            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            //Like SQL, but gets order right!
            //Start with From, where you pull data from
            //Go to Where, with conditions
            //Then do Select to tell what data to take out of the data source


            //This example returns the addresses just as the Id (1,2,3), no Join
            var results = (from c in contacts  //c is alias
                           where c.Addresses.Count > 1
                           select c);  

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }


        private static void JoinSelect()
        {

            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            //This joins the two data lists (One to many, not many to many)
            //Returns a new anonymous object, created on the fly
            //need to use var for this, since it's unnamed and anonymous
            //this is what var was really created for
            //NOTE: Doesn't HAVE to be anonymous. Can create existing object type
            var results = (from c in contacts  
                           join a in addresses
                           on c.Id equals a.ContactId
                           select new { c.FirstName, c.LastName, a.City, a.State });

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} " +
                    $"from {item.City}, {item.State}");
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }


        private static void SelectWhereTwoSources()
        {

            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            //Looks across two data sources and creates new Address item within
            //anonymous object in the result
            var results = (from c in contacts
                           select new { c.FirstName,
                                        c.LastName,
                                        Addresses = addresses.Where(a =>
                                        a.ContactId == c.Id) });
                           

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} " +
                    $"- {item.Addresses.Count() }");
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }


        private static void SelectWhereManyToMany()
        {

            Console.WriteLine($"Test - {MethodBase.GetCurrentMethod().Name}");

            //Does the same as above, but via a many to many approach
            var results = (from c in contacts
                           select new
                           {
                               c.FirstName,
                               c.LastName,
                               Addresses = addresses.Where(a =>
                               c.Addresses.Contains(a.Id))
                           });


            foreach (var item in results)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} " +
                    $"- {item.Addresses.Count() }");
            }

            Console.WriteLine($"End Test - {MethodBase.GetCurrentMethod().Name}  \n");
        }

        #endregion LinqTests








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
