using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieApp {
    public partial class WatchList : Form {
        public WatchList() {
            InitializeComponent();
            listView1.Columns.Add("Title", 100);
            listView1.Columns.Add("Genre", 100);
            listView1.Columns.Add("IMDB Rating", 50);
            listView1.Columns.Add("Certification", 200);
            listView1.Columns.Add("Length", 150);
            listView1.Columns.Add("Star Actor", 100);
            listView1.Columns.Add("Director", 100);
            listView1.Columns.Add("Year", 50);
            listView1.Columns.Add("Your rating", 50);
            listView1.View = View.Details;
        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void loadIntoList() {
            List<Movie> movies = Util.getAllMovies("Resources/watchlist.xml");
            List<ListViewItem> items = new List<ListViewItem>();
            for (int i = 0; i < movies.Count; i++) {
                string[] itemToAdd = {movies[i].title,movies[i].genres[0],movies[i].rating,movies[i].certification,movies[i].length,
                    movies[i].actors[0],movies[i].director,movies[i].year};
                items.Add(new ListViewItem(itemToAdd));
            }
            listView1.Items.AddRange(items.ToArray());
            listView1.View = View.Details;
        }

        private void WatchList_Load(object sender, EventArgs e) {
            loadIntoList();
        }

        private void button1_Click(object sender, EventArgs e) {
            add();
        }

        private void add() { }
    }
}
