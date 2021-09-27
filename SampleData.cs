using System;
using System.Collections.Generic;
using TImCoreyLambdaLesson.Models;

namespace TImCoreyLambdaLesson
{
    public static class SampleData
    {
        public static List<ContactModel> GetContactData()
        {
            List<ContactModel> output = new List<ContactModel>
            {
                new ContactModel{Id = 1, FirstName = "Tim", LastName = "Corey", Addresses = new List<int>{1,2,3}},
                new ContactModel{Id = 2, FirstName = "Andy", LastName = "Terbovich", Addresses = new List<int>{1}},
                new ContactModel{Id = 3, FirstName = "Bacchus", LastName = "Dog", Addresses = new List<int>{3}},
                new ContactModel{Id = 4, FirstName = "Jim", LastName = "Johnson", Addresses = new List<int>{1,3}},
                new ContactModel{Id = 5, FirstName = "Sue", LastName = "Storm", Addresses = new List<int>{1}}
            };

            return output;
        }

        public static List<AddressModel> GetAddressData()
        {
            List<AddressModel> output = new List<AddressModel>
            {
                new AddressModel{ Id = 1, ContactId = 1, City = "New Orleans", State = "LA" },
                new AddressModel{ Id = 2, ContactId = 1, City = "Ridgway", State = "PA" },
                new AddressModel{ Id = 3, ContactId = 1, City = "Pittsburgh", State = "PA" },
                new AddressModel{ Id = 4, ContactId = 2, City = "Scranton", State = "PA" },
                new AddressModel{ Id = 5, ContactId = 3, City = "Scranton", State = "PA" },
                new AddressModel{ Id = 6, ContactId = 4, City = "Scranton", State = "PA" },
                new AddressModel{ Id = 7, ContactId = 4, City = "Scranton", State = "PA" },
                new AddressModel{ Id = 8, ContactId = 5, City = "Scranton", State = "PA" }
            };

            return output;
        }
    }
}
