using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp {
    public class Movie {
        public string title { get; set; }
        public string year { get; set; }
        public List<string> actors { get; set; }
        public string certification { get; set; }
        public string rating { get; set; }
        public string length { get; set; }
        public List<string> genres { get; set; }
        public string director { get; set; }

        public Movie(string title, string year, List<string> actors, string certification, string rating, string length, List<string> genres, string director) {
            this.title = title;
            this.year = year;
            this.actors = actors;
            this.certification = certification;
            this.rating = rating;
            this.length = length;
            this.genres = genres;
            this.director = director;
        }

        public override string ToString() {
            return title;
        }

    }
}

