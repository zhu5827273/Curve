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
using System.Threading;
using System.Diagnostics;

namespace CurveControl
{
    public partial class Form1 : Form
    {
        Random rd = new Random();
        public Form1()
        {
            InitializeComponent();
            th = new Thread(new ThreadStart(Run));
        }
        public void Run()
        {
            while(true)
            {
                int a = 1;
                textBox1.Invoke(new Action(()=> {
                    a = rd.Next(40000, 60000);
                    textBox1.Text =a.ToString();
                }));
              Stopwatch stopwatch = new Stopwatch();
              stopwatch.Start();
                button1_Click(null, null);
                Console.WriteLine("数据："+ a.ToString()+" 运行时间："+stopwatch.ElapsedMilliseconds);
                stopwatch.Restart();
                stopwatch.Stop();
              // Thread.Sleep(50);
            }
        }
        
        Thread th = null;
        BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;

        private void button1_Click(object sender, EventArgs e)
        {
            List<AxisLineParam> listAxisParam = new List<AxisLineParam>();
            CanvasParam canvasparam = new CanvasParam();
            Pen p = new Pen(Color.Blue, 1); 
            BufferedGraphics myBuffer = currentContext.Allocate(panel1.CreateGraphics(), panel1.ClientRectangle);
            Graphics g = myBuffer.Graphics;
            g.Clear(this.BackColor);
            this.DoubleBuffered = true;
            canvasparam.ArrowLength = 6;
            canvasparam.g = g;
            canvasparam.OriginX = 43;
            canvasparam.OriginY = 355;
            canvasparam.VerticalLength = 350;
            canvasparam.HorizontalLength =1000;
            canvasparam.BlankLegend = 30;
            canvasparam.ScaleLength = 5;
            canvasparam.ScalePadding =0;
            AxisLineParam bHParam = new AxisLineParam();
            bHParam.Direction = LineDirection.Horizontal;
            bHParam.MaxScale =100000;
            bHParam.MinScale = 0;
            bHParam.CellScale = 10000;
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

            AxisLineParam PowerParam = new AxisLineParam();
            PowerParam.Direction = LineDirection.Vertical;
            PowerParam.showVirtualLine = ShowVirtualLine.Hide;
            PowerParam.lineLocation = LineLocation.Right;
            PowerParam.MaxScale = 500;
            PowerParam.MinScale = 0;
            PowerParam.CellScale = 100;
            PowerParam.Caption = "功率";
            PowerParam.Attributes = "Power";
            PowerParam.Index = 0;
            BaseLine bPower = new AxisLine(canvasparam, PowerParam);
            bPower.Draw(p);
            listAxisParam.Add(bVParam);
            listAxisParam.Add(bHParam);
            listAxisParam.Add(PowerParam);
            DataLine dl = new DataLine(canvasparam, listAxisParam, "Temp");
            dl.lineWith = 2;
            dl.listData = CreateData(Convert.ToInt32(textBox1.Text));
            dl.Draw(p);
            myBuffer.Render();
            myBuffer.Dispose();
            g.Dispose();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "X:" + e.X.ToString() + " Y:" + e.Y.ToString();
        }
        private List<LineDataModel> CreateData(int count)
        {
            List<LineDataModel> data = new List<LineDataModel>();
            Random rd = new Random();
            for (int i = 0; i < count; i++)
            {
                LineDataModel ldm = new LineDataModel();
                ldm.dataUnit = DataUnit.M;
                ldm.Times = 1F;
                ldm.Values = rd.Next(-20,20);
                data.Add(ldm);
            }
            return data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Width = 1200;
            th.Start();
            //DataLine dl = new DataLine(canvasparam, listAxisParam, "Temp");
            ////dl.Attributes = "Temp";
            //dl.lineWith = 2;
            //dl.listData = CreateData(3000);
            ////Thread.Sleep(500);
            //dl.Draw(p);
        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           // button1_Click(null, null);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
