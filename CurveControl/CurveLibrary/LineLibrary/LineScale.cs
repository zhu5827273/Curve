﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveLibrary.LineLibrary
{
    public class LineScale:BaseLine
    {
        private List<PointF> listpointS = new List<PointF>();
        private List<PointF> listpointE = new List<PointF>();
        private LineParam lp { set; get; }
        float Hlength { set; get; }//纵向减去箭头的长度
        float Vlength { set; get; }//横向向减去箭头的长度
        private float ScaleCount { set; get; }
        private float cellLength { set; get; }
        public LineScale(CanvasParam _cp, LineParam lp)
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
            if (listpointE.Count==0)
            {
                return;
            }
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 12, FontStyle.Regular, GraphicsUnit.Pixel);
            string strVlaue = "";
            float showVlaue = 0;
            for (int i = 0; i < (ScaleCount+1); i++)
            {
                cp.g.DrawLine(pen, listpointS[i], listpointE[i]);
                if (lp.Direction == LineDirection.Vertical)
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    cp.g.DrawString((lp.MinScale + i * lp.CellScale).ToString(), font, Brushes.Black, listpointE[i].X, listpointE[i].Y,sf);
                }
                else
                {
                    showVlaue = lp.MinScale + i * lp.CellScale;
                    if (lp.lineLocation == LineLocation.Left)
                    {
                        StringFormat sf = new StringFormat();
                        sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                        strVlaue = showVlaue < 0 ? Math.Abs(showVlaue).ToString()+ "-" : (showVlaue).ToString();
                        cp.g.DrawString(strVlaue, font, Brushes.Black, listpointE[i].X - cp.ScalePadding, listpointE[i].Y - 7, sf);
                    }
                    else
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        cp.g.DrawString(showVlaue.ToString(), font, Brushes.Black, listpointE[i].X + cp.ScalePadding, listpointE[i].Y -7, sf);
                    }
                    
                }
                
            }
        }
        //竖向
        private void calculateHorizontal()
        {
            cellLength = Vlength / ScaleCount;//求单位长度
            if (lp.lineLocation == LineLocation.Left)
            {
                calculateHorizontalLeft();
            }
            else
            {
                calculateHorizontalRight();
            }
        }
        private void calculateHorizontalRight()
        {
            cellLength = Vlength / ScaleCount;//求单位长度
            for (int i = 0; i < (ScaleCount + 1); i++)
            {
                PointF pfS = new PointF();
                PointF pfE = new PointF();
                pfS.X = StartPointX;
                pfS.Y = StartPointY - cellLength * (i + 1);
                pfE.X = StartPointX + cp.ScaleLength;
                pfE.Y = StartPointY - cellLength * (i + 1);
                listpointS.Add(pfS);
                listpointE.Add(pfE);
            }
        }
        private void calculateHorizontalLeft()
        {
            cellLength = Vlength / ScaleCount;//求单位长度
            for (int i = 0; i < (ScaleCount+1); i++)
            {
                PointF pfS = new PointF();
                PointF pfE = new PointF();
                pfS.X = StartPointX;
                pfS.Y = StartPointY - cellLength * i;
                pfE.X = StartPointX - cp.ScaleLength;
                pfE.Y = StartPointY - cellLength * i;
                listpointS.Add(pfS);
                listpointE.Add(pfE);
            }
        }
        //横向刻度
        private void calculateVertical()
        {
            cellLength = Hlength / ScaleCount;//求单位长度
            for (int i = 0; i < (ScaleCount + 1); i++)
            {
                PointF pfS = new PointF();
                PointF pfE = new PointF();
                pfS.X = StartPointX + cellLength * i;
                pfS.Y = StartPointY;
                pfE.X = StartPointX + cellLength * i;
                pfE.Y = StartPointY + cp.ScaleLength;
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
