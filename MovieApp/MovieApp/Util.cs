using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MovieApp {
    public static class Util {
        public static List<Movie> getAllMovies() {
            XmlTextReader reader = new XmlTextReader("Resources/movies.xml");
            XmlNodeType type;
            List<Movie> movieList = new List<Movie>();
            List<string> genres = new List<string>();
            List<string> actors = new List<string>();
            string title = "";
            string year = "";
            string certification = "";
            string rating = "";
            string length = "";
            string director = "";
            int i = 0;
            while (reader.Read()) {
                type = reader.NodeType;
                if (type == XmlNodeType.Element) {
                    switch (reader.Name) {

                        case "title":
                            reader.Read();
                            title = reader.Value;
                           
                            genres = new List<string>();
                            actors = new List<string>();
                            break;

                        case "year":
                            reader.Read();
                            year = reader.Value;
                            break;

                        case "actor":
                            reader.Read();
                            actors.Add(reader.Value);
                            break;

                        case "certification":
                            reader.Read();
                            certification = reader.Value;
                            break;

                        case "rating":
                            reader.Read();
                            rating = reader.Value;
                            break;

                        case "length":
                            reader.Read();
                            length = reader.Value;
                            break;

                        case "genre":
                            reader.Read();
                            genres.Add(reader.Value);
                            break;

                        case "director":
                            reader.Read();
                            director = reader.Value;
                            break;
                    }
                        if(reader.Name== "movie" && title != "") {
                            movieList.Add(new Movie(title, year, actors, certification, rating, length, genres, director));
                        }
                }
                i++;
                
            }

            reader.Close();
            return movieList;
        }


        public static List<Movie> searchByTitle(List<Movie> movies, string title) {
            List<Movie> result = new List<Movie>();
            for (int i = 0; i < movies.Count; i++) {
                if (title.Length > 1) {
                    result = movies;
                }
                else if (movies[i].title[0] == title[0]) {
                    result.Add(movies[i]);
                }

            }

            return result;

        }

        public static List<Movie> searchByDirector(List<Movie> movies, string director) {
            List<Movie> result = new List<Movie>();
            for (int i = 0; i < movies.Count; i++) {
                if (director.Length > 1) {
                    result = movies;
                }
                else if (movies[i].director[0] == director[0]) {
                    result.Add(movies[i]);
                }
            }

            return result;
        }

        public static List<Movie> searchByActor(List<Movie> movies, string actor) {
            List<Movie> result = new List<Movie>();
            for (int i = 0; i < movies.Count; i++) {
                if (actor.Length > 0) {
                    result = movies;
                }
                else {
                    for (int j = 0; j < movies[i].actors.Count; j++) {
                        if (movies[i].actors[j][0] == actor[0]) {
                            result.Add(movies[i]);
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public static void updateList() {
            getAllMovies();
        }

        public static List<Movie> getFinalList(List<Movie> combinedMovies, string genre) {
            List<Movie> final = combinedMovies.Distinct().ToList();
            List<Movie> movies = new List<Movie>();
            for (int i = 0; i < final.Count; i++) {
                if (final[i].genres.Contains(genre)) {
                    movies.Add(final[i]);
                }
            }
            return movies;
        }

        public static void printMovies(List<Movie> movies) {
            

        }


    }
}



