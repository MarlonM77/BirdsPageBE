using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Models
{
    [Dapper.Contrib.Extensions.Table("\"Account\"")]
    public class Account
    {
        [Key]
        public string AccountId { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public DateTime DateClose { get; set; }
        public bool IsActive { get; set; } = true;
        public string City { get; set; }
        public string Country { get; set; }
    }
}
