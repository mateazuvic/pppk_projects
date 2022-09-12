using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK2.Models
{
    public class TVShow
    {
        public int IDShow { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public Person TVHost { get; set; }
    }
}
