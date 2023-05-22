using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Models
{
    public class Birds
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BiologyName { get; set; }
        public string Region { get; set; }
        public bool ExtinctionWarning { get; set; }
        public string Recomended { get; set; }
        public int ShowPeopple { get; set; }
    }
}
