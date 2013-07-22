using System.Collections.Generic;

namespace MovieFinder.Core.Model
{
    public class RootObject
    {
        public string link_template { get; set; }
        public Links links { get; set; }
        public List<Movie> movies { get; set; }
        public int total { get; set; }
    }
}