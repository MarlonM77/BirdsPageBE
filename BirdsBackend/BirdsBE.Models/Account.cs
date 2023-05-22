using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Models
{
    public class Account
    {
        public string id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateClose { get; set; }
        public bool IsActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
