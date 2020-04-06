using System;
using System.IO;
using System.Windows.Forms;

namespace TRPOLAB2
{
    partial class MainForm : Form
    {
        public Polygon[] polygons;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManualInputForm manualInputForm = new ManualInputForm();
            manualInputForm.show(this, ref polygons);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void exitApp() {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            polygons = new Polygon[4];
            polygons[0] = new Polygon(new Condition[] {
            new Condition(new Line(new Point(0,5), new Point(0,0)),1,false),
            new Condition( new Line(new Point(0,0), new Point(2,0)),2,false),
            new Condition( new Line(new Point(2,0), new Point(4,4)),1,false),
            new Condition( new Line(new Point(4,4), new Point(0,5)),2,false)});
            polygons[3] = new Polygon(new Condition[] {
            new Condition( new Line(new Point(0, 5), new Point(4, 4)),2,false),
            new Condition( new Line(new Point(4, 4), new Point(6, 6)),1,true),
            new Condition( new Line(new Point(6, 6), new Point(10, 7)),1,true),
            new Condition( new Line(new Point(10, 7), new Point(0, 7)),2,false),
            new Condition( new Line(new Point(0, 7), new Point(0, 5)),1,false)} );
            polygons[1] = new Polygon(new Condition[] {
            new Condition( new Line(new Point(2,0), new Point(4,4)),2,false),
            new Condition( new Line(new Point(4,4), new Point(6,6)),2,false),
            new Condition( new Line(new Point(6,6), new Point(9,0)),1,false),
            new Condition( new Line(new Point(9,0), new Point(2,0)),2,false)} );
            polygons[2] = new Polygon(new Condition[] {
            new Condition( new Line(new Point(9,0), new Point(6,6)),1,false),
            new Condition( new Line(new Point(6,6), new Point(10,7)),2,false),
            new Condition( new Line(new Point(10,7), new Point(10,0)),1,false),
            new Condition( new Line(new Point(10,0), new Point(9,0)),2,false) });

            using (StreamWriter writer = File.AppendText("coordinates.txt"))
            {
                writer.Close();
            }
            using (StreamWriter writer = File.CreateText("inspectionResult.txt"))
            {
                writer.Close();
            }
        }

        public Polygon[] GetPolygons() => this.polygons;
    }
}
