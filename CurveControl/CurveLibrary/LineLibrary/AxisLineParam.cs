using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveLibrary.LineLibrary
{
    public class AxisLineParam
    {
        public float MaxScale { set; get; }//最大刻度
        public float MinScale { set; get; }//最小刻度
        public float CellScale { set; get; }//单位刻度
        public LineDirection Direction { set; get; }//线的方向
        public ShowVirtualLine showVirtualLine { set; get; }//是否显示虚线
        public LineLocation lineLocation { set; get; }
        public String Caption { set; get; }
        public String Attributes { set; get; }
        public int Index { set; get; }
    }
}
