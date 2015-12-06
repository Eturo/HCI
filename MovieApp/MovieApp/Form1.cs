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
            this.chart1.MouseClick += new MouseEventHandler(this.chart1_MouseClick);
            
        }

        private void button1_Click(object sender, EventArgs e) {
            pictureBox1.Visible = false;
            //AdminPage admin = new AdminPage();
            //admin.Show();
            //showAllInListBox();
            //MessageBox.Show("List count is:" + listBox1.Items.Count);

            // Search(gets list of searchedMovies)
            List<Movie> allMovies = Util.getAllMovies();

            int titleVal = (trackBar1.Value+64);
            string title = Convert.ToChar(titleVal).ToString();

            int actorVal = trackBar2.Value+64;
            string actor = Convert.ToChar(actorVal).ToString();
            int directorVal = trackBar3.Value+64;

            string director = Convert.ToChar(directorVal).ToString();
            List<string> certs = getCerts();

            List<Movie> titleSearch = Util.searchByTitle(allMovies, title);
            List<Movie> actorSearch = Util.searchByTitle(allMovies, actor);
            List<Movie> directorSearch = Util.searchByTitle(allMovies, director);

            //List<Movie> searchedMovies = titleSearch; //just for testing
            List<Movie> searchedMovies = Util.getFinalList(titleSearch.Concat(actorSearch.Concat(directorSearch)).ToList(), "Action");
            // End of Search

            // Generate ScatterPlot
            chart1.Visible = true;
            chart1.ChartAreas[0].AxisX.Minimum = 1920;
            chart1.ChartAreas[0].AxisX.Maximum = 2020;
            chart1.ChartAreas[0].AxisX.Interval = 20;

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


      
    }
}
