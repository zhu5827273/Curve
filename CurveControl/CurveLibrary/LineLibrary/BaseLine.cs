using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveLibrary.LineLibrary
{
  public abstract class BaseLine
    {
        public CanvasParam cp { set; get; }
        //规定箭头方向为结束方向
        public float LineLength { set; get; }
        public float StartPointX { set; get; }
        public float StartPointY { get; set; }
        public float EndPointX { get; set; }
        public float EndPointY { set; get; }
        public abstract void Draw(Pen p);
    }
}

