using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurveLibrary;
using CurveLibrary.LineLibrary;
namespace CurveControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Blue, 1);
            Graphics g = this.CreateGraphics();
            CanvasParam canvasparam = new CanvasParam();
            canvasparam.ArrowLength = 6;
            canvasparam.g = g;
            canvasparam.OriginX = 43;
            canvasparam.OriginY = 355;
            canvasparam.VerticalLength = 350;
            canvasparam.HorizontalLength = 1000;
            canvasparam.BlankLegend = 10;
            canvasparam.ScaleLength = 5;
            canvasparam.ScalePadding =0;
            LineParam bHParam = new LineParam();
            bHParam.Direction = LineDirection.Horizontal;
            bHParam.MaxScale = 80;
            bHParam.MinScale = -40;
            bHParam.CellScale = 10;
            bHParam.showVirtualLine = ShowVirtualLine.Visible;
            AxisLine bH = new AxisLine(canvasparam,bHParam);
            bH.Draw(p);        

            LineParam bVParam = new LineParam();
            bVParam.Direction = LineDirection.Vertical;
            bVParam.showVirtualLine = ShowVirtualLine.Visible;
            bVParam.MaxScale = 115;
            bVParam.MinScale = 0;
            bVParam.CellScale = 5;
            AxisLine bV = new AxisLine(canvasparam, bVParam);
            bV.Draw(p);          
        }

        private void Form1_Click(object sender, EventArgs e)
        {
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "X:" + e.X.ToString() + " Y:" + e.Y.ToString();
        }
    }
}
