using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace MovieApp {
    public partial class Form1 : Form {
        Point? clickPosition = null;
        ToolTip tooltip = new ToolTip();
        public Form1() {
            InitializeComponent();
      //      this.chart1.MouseClick += new MouseEventHandler(this.chart1_MouseClick);
            
        }

        private void button1_Click(object sender, EventArgs e) {
            pictureBox1.Visible = false;
            //AdminPage admin = new AdminPage();
            //admin.Show();
            //showAllInListBox();
            //MessageBox.Show("List count is:" + listBox1.Items.Count);

            // Search(gets list of searchedMovies)
            List<Movie> allMovies = Util.getAllMovies("Resources/movies.xml");

            int titleVal = (trackBar1.Value+64);
            char title = Convert.ToChar(titleVal);

            int actorVal = trackBar3.Value+64;
            char actor = Convert.ToChar(actorVal);

            int directorVal = trackBar2.Value+64;
            char director = Convert.ToChar(directorVal);
            List<string> certs = getCerts();

            List<Movie> searchMovies = Util.search(allMovies, title, actor, director);

            //List<Movie> searchedMovies = titleSearch; //just for testing
            List<Movie> searchedMovies = Util.getFinalList(searchMovies, "Crime");
            // End of Search

            // Generate ScatterPlot
            chart1.Visible = true;
            chart1.ChartAreas[0].AxisX.Minimum = 1920;
            chart1.ChartAreas[0].AxisX.Maximum = 2020;
            chart1.ChartAreas[0].AxisX.Interval = 20;
            clearChart();
            listBox1.Items.Clear();

            int point;
            for (int i=0; i<searchedMovies.Count; i++)
            {
                if (searchedMovies[i].genres[0] == "Action"){
                    point = this.chart1.Series["Action"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Action"].Points[point].ToolTip = searchedMovies[i].title;
                    this.chart1.Series["Action"].Points[point].Name = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Adventure")
                {
                    point = this.chart1.Series["Adventure"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Adventure"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "History")
                {
                    point = this.chart1.Series["History"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["History"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Romance")
                {
                    point = this.chart1.Series["Romance"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Romance"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "War")
                {
                    point = this.chart1.Series["War"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["War"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Drama")
                {
                    point = this.chart1.Series["Drama"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Drama"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Animation")
                {
                    point = this.chart1.Series["Animation"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Animation"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Sci-Fi")
                {
                    point = this.chart1.Series["Sci-Fi"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Sci-Fi"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Western")
                {
                    point = this.chart1.Series["Western"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Western"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Comedy")
                {
                    point = this.chart1.Series["Comedy"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Comedy"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Crime")
                {
                    point = this.chart1.Series["Crime"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Crime"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Mystery")
                {
                    point = this.chart1.Series["Mystery"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Mystery"].Points[point].ToolTip = searchedMovies[i].title;
                }

                if (searchedMovies[i].genres[0] == "Thriller")
                {
                    point = this.chart1.Series["Thriller"].Points.AddXY(Int32.Parse(searchedMovies[i].year), Int32.Parse(searchedMovies[i].rating));
                    this.chart1.Series["Thriller"].Points[point].ToolTip = searchedMovies[i].title;
                    this.chart1.Series["Thriller"].Points[point].Name = searchedMovies[i].title;
                }
            }
            //End of Generate ScatterPlot

            for (int i = 0; i < searchedMovies.Count; i++) {
                listBox1.Items.Add(searchedMovies[i]);
            }

            //End of Populate List Box

            //Generate ListView
            this.listView1.View = View.Details;
            this.listView1.Columns.Add("Director", 80);
            this.listView1.Columns.Add("Actors", 80);
            this.listView1.Columns.Add("Genres", 80);
            this.listView1.Columns.Add("Rating", 80);
            this.listView1.Columns.Add("Year Made", 80);
            this.listView1.Columns.Add("Length", 80);
            this.listView1.Columns.Add("Certification", 80);
            //End of Generate ListView
            //End of Generate ScatterPlot

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

       /* void chart1_MouseClick(object sender, MouseEventArgs e) {
            var pos = e.Location;
            clickPosition = pos;
            var results = this.chart1.HitTest(pos.X, pos.Y, false,
                                         ChartElementType.PlottingArea);
            foreach (var result in results) {
                if (result.ChartElementType == ChartElementType.PlottingArea) {
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

            //        var dataPoint = chart1.Series["Action"].Points.FindAllByValue("D");
                }
            }
        }*/

        private List<string> getCerts() {
            List<string> certs = new List<string>();
            if (checkBox1.Checked)
                certs.Add(checkBox1.Text);
            if (checkBox2.Checked)
                certs.Add(checkBox2.Text);
            if (checkBox3.Checked)
                certs.Add(checkBox3.Text);
            if (checkBox4.Checked)
                certs.Add(checkBox4.Text);
            return certs;

        }

        private void button2_Click(object sender, EventArgs e) {
            WatchList wl = new WatchList();
            wl.Show();
        }

        private void label9_Click(object sender, EventArgs e) {

        }

        private void label11_Click(object sender, EventArgs e) {

        }

        private void chart1_Click(object sender, EventArgs e) {

        }

        private void label15_Click(object sender, EventArgs e) {

        }

        private void clearChart() {
            //Clear Chart
            if (chart1.Series.Contains(chart1.Series["Action"])) {
                this.chart1.Series["Action"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Adventure"])) {
                this.chart1.Series["Adventure"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Romance"])) {
                this.chart1.Series["Romance"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["War"])) {
                this.chart1.Series["War"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Drama"])) {
                this.chart1.Series["Drama"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Animation"])) {
                this.chart1.Series["Animation"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Western"])) {
                this.chart1.Series["Western"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Comedy"])) {
                this.chart1.Series["Comedy"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Thriller"])) {
                this.chart1.Series["Thriller"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Crime"])) {
                this.chart1.Series["Crime"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Mystery"])) {
                this.chart1.Series["Mystery"].Points.Clear();
            }
            if (chart1.Series.Contains(chart1.Series["Sci-Fi"])) {
                this.chart1.Series["Sci-Fi"].Points.Clear();
            }
            //End of clear chart
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            Movie sm = (Movie)listBox1.SelectedItem;
            var item = new ListViewItem(new[] { sm.director, sm.actors[0], sm.genres[0], sm.rating, sm.year, sm.length, sm.certification });
            listView1.Items.Clear();
            listView1.Items.Add(item);
        }


    }
}
