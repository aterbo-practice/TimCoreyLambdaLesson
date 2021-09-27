using System;
using System.Collections.Generic;

namespace TImCoreyLambdaLesson.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Addresses { get; set; }
    }
}
