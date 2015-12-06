using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MovieApp {
    public partial class AdminPage : Form {
        AddEdit ae = new AddEdit();
        public AdminPage() {
            InitializeComponent();
            listView1.Columns.Add("Title", 100);
            listView1.Columns.Add("Genre", 100);
            listView1.Columns.Add("Rating", 50);
            listView1.Columns.Add("Certification", 200);
            listView1.Columns.Add("Length", 150);
            listView1.Columns.Add("Star Actor", 100);
            listView1.Columns.Add("Director", 100);
            listView1.Columns.Add("Year", 50);
            listView1.View = View.Details;
        }

        private void AdminPage_Load(object sender, EventArgs e) {
            loadIntoList();
        }

        private void loadIntoList() {
            List<Movie> movies = Util.getAllMovies();
            List<ListViewItem> items = new List<ListViewItem>();
            for (int i = 0; i < movies.Count; i++) {
                string[] itemToAdd = {movies[i].title,movies[i].genres[0],movies[i].rating,movies[i].certification,movies[i].length,
                    movies[i].actors[0],movies[i].director,movies[i].year};
                items.Add(new ListViewItem(itemToAdd));
            }
            listView1.Items.AddRange(items.ToArray());
            listView1.View = View.Details;
        }

        private void delete() {
            var doc = new System.Xml.XmlDocument();
            doc.Load("Resources/movies.xml");
            var title = listView1.SelectedItems[0].SubItems[0].Text;
            XmlElement element = (XmlElement)doc.SelectSingleNode("/movielist/movie[title[text()='" + title + "']]");

            if (element != null) {
                element.ParentNode.RemoveChild(element);
                doc.Save("Resources/movies.xml");
            }
            Util.updateList();
            listView1.SelectedItems[0].Remove();
        }

        private void add() {
            ae.Show();
        }

        private void button3_Click(object sender, EventArgs e) {
            delete();
        }

        private void callEdit() {
            ae.edit(
                listView1.SelectedItems[0].SubItems[0].Text,
                listView1.SelectedItems[0].SubItems[1].Text,
                listView1.SelectedItems[0].SubItems[2].Text,
                listView1.SelectedItems[0].SubItems[3].Text,
                listView1.SelectedItems[0].SubItems[4].Text,
                listView1.SelectedItems[0].SubItems[5].Text,
                listView1.SelectedItems[0].SubItems[6].Text,
                listView1.SelectedItems[0].SubItems[7].Text);
         
        }

        private void button2_Click(object sender, EventArgs e) {
            callEdit();
        }
    }
}
