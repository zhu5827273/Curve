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
        public List<LineDataModel> listData { set; get; }
        public List<AxisLineParam> listCP { set; get; }
        public string Attributes { set; get; }
        private List<PointF> data = new List<PointF>();
        public String Caption { set; get; }
        //public String Attributes { set; get; }
        public Color color { set; get; }//线颜色
        public float lineWith { set; get; }//线粗细
        private AxisLineParam Vlp { set; get; }
        private AxisLineParam Hlp { set; get; }
        private float HUnit{ set; get; }//横向单位刻度以分钟为基准
        private float VUnit { set; get; }//竖向单位以1位单位
        public DataLine(CanvasParam _cp, List<AxisLineParam> listCP,string Attributes) :base(_cp)
        {
            lineWith = 0;
            color = Color.Red;
            // this.Attributes = Attributes;
            this.Hlp = listCP.Find(t => t.Attributes == "Time");
            this.Vlp = listCP.Find(t => t.Attributes == Attributes);
        }
        private void findLineParam()
        {

        }
        public override void Draw(Pen p)
        {
            calculate();
            p.Width = lineWith;
            p.Color = color;
            PointF[] pfdata= data.ToArray();
            cp.g.DrawLines(p,pfdata);
        }
        private void calculate()
        {
            if (listData==null)
            {
                return;
            }
            findLineParam();
            HUnit = Hlength / (Hlp.MaxScale - Hlp.MinScale);
            VUnit = Vlength / (Vlp.MaxScale - Vlp.MinScale);
            for (int i = 0; i < listData.Count; i++)
            {
                PointF pf = new PointF();
                if (listData[i].dataUnit == DataUnit.M)
                {
                    pf.X =cp.OriginX+ (i+1) * HUnit*listData[i].Times;
                }
                else if (listData[i].dataUnit == DataUnit.S)
                {
                    pf.X = cp.OriginX + (i + 1) * (HUnit / 60) * listData[i].Times;
                }
                else
                {
                    pf.X = cp.OriginX + (i + 1) * (HUnit *60) * listData[i].Times;
                }
                pf.Y =cp.OriginY-(listData[i].Values-Vlp.MinScale) * VUnit;
                if (pf.X>Hlength+StartPointX)
                {
                    break;
                }
                data.Add(pf);
            }
        }
    }
}
