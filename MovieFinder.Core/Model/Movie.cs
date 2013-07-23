using System.Collections.Generic;
using Cirrious.MvvmCross.Plugins.Sqlite;

namespace MovieFinder.Core.Model
{
    public class Movie
    {
        [Ignore]
        public List<AbridgedCast> abridged_cast { get; set; }
        [Ignore]
        public AlternateIds alternate_ids { get; set; }
        public string id { get; set; }
        [Ignore]
        public Links2 links { get; set; }
        public string mpaa_rating { get; set; }
        [Ignore]
        public Posters posters { get; set; }
        [Ignore]
        public Ratings ratings { get; set; }
        [Ignore]
        public ReleaseDates release_dates { get; set; }
        [Ignore]
        public object runtime { get; set; }
        public string synopsis { get; set; }
        public string title { get; set; }
        public int year { get; set; }
    }
}