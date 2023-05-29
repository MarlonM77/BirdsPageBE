using AutoMapper.Configuration.Annotations;
using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirdsBE.Models
{
    [Dapper.Contrib.Extensions.Table("\"Users\"")]
    public class Users
    {
        public string Alias { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string WasBorn { get; set; }
        public DateTime DateBorn { get; set; }
        public string EmailAddress { get; set; }
        public string ProfilePicture { get; set; }
        public string AccountId { get; set; }
        [Write(false)]
        public Account Account { get; set; }
    }
}
