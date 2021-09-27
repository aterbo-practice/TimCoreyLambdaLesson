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
                new ContactModel{Id = 5, FirstName = "Sur", LastName = "Storm", Addresses = new List<int>{1}}
            };

            return output;
        }
    }
}
