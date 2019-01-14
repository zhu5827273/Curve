using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveLibrary.LineLibrary
{
    public class AxisLine:BaseLine
    {
        public LineParam lp { set; get; }
        public AxisLine(CanvasParam _cp, LineParam lp)
        {
            cp = _cp;
            this.lp = lp;
        }
        public override void Draw(Pen p)
        {
            calculate();
            cp.g.DrawLine(p, StartPointX, StartPointY, EndPointX, EndPointY);
            arrow(new SolidBrush(p.Color));
            if (ShowVirtualLine.Visible == lp.showVirtualLine)//绘制虚线
            {
                VirtualLine vl = new VirtualLine(cp, lp);
                vl.Draw(p);
            }
            LineScale ls = new LineScale(cp, lp);//刻度线
            ls.Draw(p);
        }

        private void arrow(SolidBrush b)
        {
            float arrowLength = cp.ArrowLength;
            PointF[] points = new PointF[3];
            points[0].X = EndPointX;
            points[0].Y = EndPointY;
            if (LineDirection.Vertical == lp.Direction)
            {
                points[1].X = EndPointX - arrowLength / 2;
                points[1].Y = EndPointY + arrowLength;
                points[2].X = EndPointX + arrowLength / 2;
                points[2].Y = EndPointY + arrowLength;
            }
            else
            {
                points[1].X = EndPointX - arrowLength;
                points[1].Y = EndPointY + arrowLength / 2;
                points[2].X = EndPointX - arrowLength;
                points[2].Y = EndPointY - arrowLength / 2;
            }
            cp.g.FillPolygon(b, points);
        }
        private void calculate()
        {
            StartPointX = cp.OriginX;
            StartPointY = cp.OriginY;
            if (lp.Direction == LineDirection.Vertical)
            {
                EndPointX = cp.OriginX;
                EndPointY = StartPointY - cp.VerticalLength;
            }
            else
            {
                EndPointX = cp.OriginX + cp.HorizontalLength;
                EndPointY = cp.OriginY;
            }
        }
    }
}
