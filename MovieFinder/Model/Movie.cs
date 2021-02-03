using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinder
{
    public class Movie
    {
        public string Name { get; set; }
        public float Size { get; set; }
        public string PathName { get; set; }
        public DateTime Created { get; set; }
        public string Length { get; set; }
        public string Type { get; set; }
    }
}
