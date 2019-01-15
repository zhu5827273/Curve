using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveLibrary.LineLibrary
{
    public class DataLine : BaseLine
    {
        public List<LineDataModel> listData = new List<LineDataModel>();
        private List<PointF> data = new List<PointF>();
        public DataLine(CanvasParam _cp, AxisLineParam lp):base(_cp,lp)
        {
            //cp = _cp;
            //this.lp = lp;
            //StartPointX = cp.OriginX;
            //StartPointY = cp.OriginY;
            //ScaleCount = (lp.MaxScale - lp.MinScale) / lp.CellScale;//计算多少刻度
            //Hlength = cp.HorizontalLength - cp.ArrowLength - cp.BlankLegend;//减去箭头的长度
            //Vlength = cp.VerticalLength - cp.ArrowLength - cp.BlankLegend;
        }
        public override void Draw(Pen p)
        {
            throw new NotImplementedException();
        }
    }
}
