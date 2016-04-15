using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_2
{
    public class Point
    {
        //Point's coordinates
        public double x;
        public double y ;
        public Point(double x_, double y_)
        {
            x = x_;
            y = y_;
        }
    }
    public class Square
    {
        public Point center;
        private double _angle = 0;
        public Point[] nodes = new Point[4];
        public Point pixel = new Point(0, 0);

        private double _radius;
        private double _zoom =1;

        public void SetAngle(double x)
        {
            //if (_angle + x >= 360)
            //    _angle += x - 360;
            //else
                _angle += x;
        }
        public double GetAngle()
        {
            return _angle*Math.PI/180;
        }
        public void SetZoom(double x) { if(_zoom+x>0) _zoom += x; }
        public double GetZoom() { return _zoom; }


        public Square(Point x, Point r)
        {
            center = x;
            _radius = Math.Sqrt(Math.Pow(center.x-r.x, 2) + Math.Pow(center.y - r.y, 2));
           
            SetNods();
        }

        private void SetNods()
        {
            Point bufPoint1=new Point(0, 0), bufPoint2 = new Point(0, 0), bufPoint3 = new Point(0, 0), bufPoint4 = new Point(0, 0);
            bufPoint1.x = center.x - _radius;
            bufPoint1.y = center.y;
            nodes[0]=bufPoint1;
            bufPoint2.x = center.x;
            bufPoint2.y = center.y - _radius;
            nodes[1] = bufPoint2;
            bufPoint3.x = center.x + _radius;
            bufPoint3.y = center.y;
            nodes[2] = bufPoint3;
            bufPoint4.x = center.x;
            bufPoint4.y = center.y + _radius;
            nodes[3] = bufPoint4;
        }


    }
}
