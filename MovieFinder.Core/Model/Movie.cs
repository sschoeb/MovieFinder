using System.Collections.Generic;

namespace MovieFinder.Core.Model
{
    public class Movie
    {
        public List<AbridgedCast> abridged_cast { get; set; }
        public AlternateIds alternate_ids { get; set; }
        public string id { get; set; }
        public Links2 links { get; set; }
        public string mpaa_rating { get; set; }
        public Posters posters { get; set; }
        public Ratings ratings { get; set; }
        public ReleaseDates release_dates { get; set; }
        public object runtime { get; set; }
        public string synopsis { get; set; }
        public string title { get; set; }
        public int year { get; set; }
    }
}