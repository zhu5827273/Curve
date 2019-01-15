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
            List<AxisLineParam> listAxisParam = new List<AxisLineParam>();
            Pen p = new Pen(Color.Blue, 1);
            Graphics g = this.CreateGraphics();
            CanvasParam canvasparam = new CanvasParam();
            canvasparam.ArrowLength = 6;
            canvasparam.g = g;
            canvasparam.OriginX = 43;
            canvasparam.OriginY = 355;
            canvasparam.VerticalLength = 350;
            canvasparam.HorizontalLength = 600;
            canvasparam.BlankLegend = 30;
            canvasparam.ScaleLength = 5;
            canvasparam.ScalePadding =0;

            AxisLineParam bHParam = new AxisLineParam();
            bHParam.Direction = LineDirection.Horizontal;
            bHParam.MaxScale = 60;
            bHParam.MinScale = 0;
            bHParam.CellScale = 10;
            bHParam.showVirtualLine = ShowVirtualLine.Visible;
            bHParam.Caption = "时间(分)";
            bHParam.Attributes = "Time";
            BaseLine bH = new AxisLine(canvasparam,bHParam);
            bH.Draw(p);        

            AxisLineParam bVParam = new AxisLineParam();
            bVParam.Direction = LineDirection.Vertical; 
            bVParam.showVirtualLine = ShowVirtualLine.Visible;
            bVParam.MaxScale = 40;
            bVParam.MinScale = -40;
            bVParam.CellScale = 10;
            bVParam.Caption = "温度/℃";
            bVParam.Attributes = "Temp";
            BaseLine bV = new AxisLine(canvasparam, bVParam);
            bV.Draw(p);

            listAxisParam.Add(bVParam);
            listAxisParam.Add(bHParam);
             
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "X:" + e.X.ToString() + " Y:" + e.Y.ToString();
        }
    }
}
