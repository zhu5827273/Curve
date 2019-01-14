using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveLibrary
{
   public class CanvasParam
    {
        //线箭头长度
        public float ArrowLength { get; set; }
        public float VerticalLength { set; get; } //垂直长度
        public float HorizontalLength { set; get; }//水平长度
        public float BlankLegend { set; get; }//给线标留空白
        public float OriginX { get; set; }
        public float OriginY { get; set; }
        public Graphics g { set; get; }
        public float ScaleLength { set; get; }//刻度线长度
        public float ScalePadding { set; get; }
    }
}
