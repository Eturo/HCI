using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MovieApp {
    public partial class AddEdit : Form {
        private bool isEdit;
        public AddEdit() {
            InitializeComponent();
        }

        private void AddEdit_Load(object sender, EventArgs e) {

        }

        private void save() {
            XDocument doc = XDocument.Load("Resources/movies.xml");
            XElement root = doc.Element("movielist");

            if (isEdit) {
                var target = doc.Element("movielist").Elements("movie").
                    Where(e => e.Element("title").Value == titleText.Text)
                    .FirstOrDefault();
                target.Element("title").Value = titleText.Text;
                target.Element("director").Value = directorText.Text;
                target.Element("actor").Value = actorText.Text;
                target.Element("length").Value = lengthText.Text;
                target.Element("year").Value = yearText.Text;
                target.Element("genre").Value = genreBox.Text;
                target.Element("certification").Value = certificationText.Text;
                target.Element("rating").Value = ratingText.Text;


            }
            else {
                IEnumerable<XElement> rows = root.Descendants("movie");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
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
            doc.Save("Resources/movies.xml");
            Util.updateList();
            this.Close();
        }
        public void edit(string title,string genre,string rating,string certification,string length, string actor, string director, string year) {
            this.Show();
            titleText.Text = title;
            genreBox.Text = genre;
            ratingText.Text = rating;
            certificationText.Text = certification;
            lengthText.Text = length;
            actorText.Text = actor;
            directorText.Text = director;
            yearText.Text = year;
            isEdit = true;
        }

        private void button1_Click(object sender, EventArgs e) {
            save();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
