using System;

namespace BirdsBE.Models
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public string Age { get; set; }
        public string WasBorn { get; set; }
        public DateTime DateBorn { get; set; }
        public string EmailAddress { get; set; }
        public string ProfilePicture { get; set; }
        public Account Account { get; set; }
    }
}
