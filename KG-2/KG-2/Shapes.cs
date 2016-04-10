using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_2
{
    class Point
    {
        //Point's coordinates
        public int x;
        public int y ;
        
        public Point(int x_, int y_)
        {
            x = x_;
            y = y_;
        }
    }
    class Square
    {
        public Point center;
        public Point[] nodes = new Point[4];
        private int _radius;

        public Square(Point x, Point r)
        {
            center = x;
            _radius = Convert.ToInt32(Math.Sqrt(Math.Pow(center.x-r.x, 2) + Math.Pow(center.y - r.y, 2)));
           
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
