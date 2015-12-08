using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MovieApp {
    public static class Util {
        public static List<Movie> getAllMovies(string filePath) {
            XmlTextReader reader = new XmlTextReader(filePath);
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
            try {
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
                        if (reader.Name == "movie" && title != "") {
                            movieList.Add(new Movie(title, year, actors, certification, rating, length, genres, director));
                        }
                    }


                }
            }catch(XmlException e) {
                MessageBox.Show(e.ToString());
            }

            reader.Close();
            return movieList;
        }

        public static List<Movie> search(List<Movie> movies, char title, char actor, char director) {
            List<Movie> result = new List<Movie>();
            int movieCount = movies.Count;
            //get movies with title
            if (title == '@')
                result = movies;
            else {
                for (int i = 0; i < movieCount; i++) {
                    if (movies[i].title[0] == title) {
                        result.Add(movies[i]);
                    }
                }
            }
            if (director != '@') {
                movieCount = result.Count;
                for (int i = 0; i < movieCount; i++) {
                    if (result[i].director[0] == director) {
                        result.Add(result[i]);
                    }
                }
            }
            if (actor != '@') {
                movieCount = result.Count;
                for (int i = 0; i < movieCount; i++) {
                    for (int j = 0; j < result[i].actors.Count; j++) {
                        if (result[i].actors[j][0] == actor) {
                            result.Add(result[i]);
                            break;
                        }
                    }
                }
            }
            return result;
        }


        public static void updateMovieList() {
            getAllMovies("Resources/movies.xml");
        }

        public static List<Movie> getFinalList(List<Movie> combinedMovies, List<string> genres, List<string> certs) {
            List<Movie> final = combinedMovies.Distinct().ToList();
            List<Movie> movies = new List<Movie>();
            bool ifGenre = false;
            if(genres.Count > 0){
                for (int i = 0; i < final.Count; i++) {
                    ifGenre = false;
                    for(int j =0;j< genres.Count && !ifGenre ; j++){
                        if(final[i].genres.Contains(genres[j])){
                            
                            ifGenre = true;
                        }
                    }
                    // add movie
                    if (ifGenre && certs.Count < 1)
                        movies.Add(final[i]);
                    if(certs.Contains(final[i].certification) && ifGenre)
                        movies.Add(final[i]);
                }
            }
            else{
                for(int i =0; i< final.Count ; i ++){
                    if(certs.Count < 1 || (certs.Contains(final[i].certification)))
                        movies.Add(final[i]);
                }
            }
            return movies;
        }

        public static void printMovies(List<Movie> movies) {
            

        }

        public static List<Movie> getWatchList() {
            List<Movie> watchList = getAllMovies("Resources/watchlist.xml");
            return watchList;
        }

        public static void updateWatchList() {
            getAllMovies("Resources/watchlist.xml");
        }



        }

    }

  IEnumerable<XElement> rows = root.Descendants("movie");
                XElement = 
                    new XElement("movie",
                    new XElement("title", titleText.Text),
                    new XElement("director", directorText.Text),
                    new XElement("actor", actorText.Text),
                    new XElement("length", lengthText.Text),
                    new XElement("year", yearText.Text),
                    new XElement("genre", genreBox.Text),
                    new XElement("certification", certificationText.Text),
                    new XElement("rating", ratingText.Text)));
            }


