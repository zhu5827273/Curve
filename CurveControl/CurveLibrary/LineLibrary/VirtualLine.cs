using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveLibrary.LineLibrary
{
    public class VirtualLine : BaseLine
    {
        private List<PointF> listpointS = new List<PointF>();
        private List<PointF> listpointE = new List<PointF>();
        private LineParam lp { set; get; }
        float Hlength { set; get; }//纵向减去箭头的长度
        float Vlength { set; get; }//横向向减去箭头的长度
        private float ScaleCount { set; get; }
        private float cellLength { set; get; }
        public VirtualLine(CanvasParam _cp, LineParam lp)
        {
            cp = _cp;
            this.lp = lp;
            StartPointX = cp.OriginX;
            StartPointY = cp.OriginY;
            ScaleCount = (lp.MaxScale - lp.MinScale) / lp.CellScale;//计算多少刻度
            Hlength = cp.HorizontalLength - cp.ArrowLength - cp.BlankLegend;//减去箭头的长度
            Vlength = cp.VerticalLength - cp.ArrowLength - cp.BlankLegend;
        }
        public override void Draw(Pen p)
        {
            calculate();
            Pen pen = (Pen)p.Clone();
            pen.DashStyle= DashStyle.Dash;
            for (int i = 0; i < ScaleCount; i++)
            {
                cp.g.DrawLine(pen, listpointS[i], listpointE[i]);
            }
        }
        //竖向
        private void calculateVertical()
        {
            cellLength = Hlength / ScaleCount;//求单位长度
            for (int i = 0; i < ScaleCount; i++)
            {
                PointF pfS = new PointF();
                PointF pfE = new PointF();
                pfS.X = StartPointX + cellLength * (i + 1);
                pfS.Y = StartPointY;
                pfE.X = StartPointX + cellLength * (i + 1);
                pfE.Y = StartPointY-Vlength ;
                listpointS.Add(pfS);
                listpointE.Add(pfE);
            }
        }
        //横向
        private void calculateHorizontal()
        {
            cellLength = Vlength / ScaleCount;//求单位长度
            for (int i = 0; i < ScaleCount; i++)
            {
                PointF pfS = new PointF();
                PointF pfE = new PointF();
                pfS.X = StartPointX;
                pfS.Y = StartPointY - cellLength * (i + 1);
                pfE.X = StartPointX + Hlength;
                pfE.Y = StartPointY - cellLength * (i + 1);
                listpointS.Add(pfS);
                listpointE.Add(pfE);
            }         
        }
        private void calculate()
        {
            if (lp.Direction == LineDirection.Vertical)
            {
                calculateVertical();
            }
            else
            {
                calculateHorizontal();
            }
        }
    }
}
