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
        public String Caption { set; get; }
        public String Attributes { set; get; }
        private AxisLineParam Vlp { set; get; }
        private AxisLineParam Hlp { set; get; }
        public DataLine(CanvasParam _cp, List<AxisLineParam> listCP):base(_cp)
        {
            this.Hlp = listCP.Find(t => t.Attributes == "Time");
            this.Vlp = listCP.Find(t => t.Attributes == Attributes);
        }
        public override void Draw(Pen p)
        {
            throw new NotImplementedException();
        }
        private void calculate()
        {
        }
    }
}
