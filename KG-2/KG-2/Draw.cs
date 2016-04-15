using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG_2
{
    public static class Draw
    {
       
        public static void Pixel(Point node, double pixelSide)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.Black);
            GL.Vertex2(pixelSide * node.x, pixelSide * node.y);
            GL.Vertex2(pixelSide * (node.x + 1), pixelSide * node.y);
            GL.Vertex2(pixelSide * (node.x + 1), pixelSide * (node.y + 1));
            GL.Vertex2(pixelSide * node.x, pixelSide * (node.y + 1));
            GL.End();
        }
        public static void Square(Square sq, int pixelSide)
        {
            //отрисовка вершин
            foreach (var node in sq.nodes)
            {
                //Point pixel = new Point(Math.Truncate(node.x / pixelSide), Math.Truncate(node.y / pixelSide));
                Pixel(node, pixelSide);
            }
            //отрисовка граней
           
            BresenhamsLine(sq.nodes[0], sq.nodes[1], pixelSide, Color.Red);
            BresenhamsLine(sq.nodes[1], sq.nodes[2], pixelSide, Color.Red);
            BresenhamsLine(sq.nodes[2], sq.nodes[0], pixelSide, Color.Red);
            BresenhamsLine(sq.nodes[3], sq.nodes[2], pixelSide, Color.Red);



        }
        static void swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public static void BresenhamsLine(Point p0, Point p1, int pixelSide, Color c)
        {
            var steep = Math.Abs(p1.y - p0.y) > Math.Abs(p1.x - p0.x);
            Point buf0 = p0;
            Point buf1 = p1;
            if (steep)
            {
                swap(ref buf0.x, ref buf0.y);
                swap(ref buf1.x, ref buf1.y);
            }
            if (buf0.x > buf1.x)
            {
                swap(ref buf0.x, ref buf1.x);
                swap(ref buf0.y, ref buf1.y);
            }

            GL.Color3(c);

            

            Pixel(steep ? new Point(buf0.y, buf0.x) : new Point(buf0.x, buf0.y), pixelSide);
            Pixel(steep ? new Point(buf1.y, buf1.x) : new Point(buf1.x, buf1.y), pixelSide);

            double dx = buf1.x - buf0.x;
            double dy = buf1.y - buf0.y;
            double gradient = dy / dx;
            double y = buf0.y + gradient;
            for (var x = buf0.x + 1; x <= buf1.x - 1; x++)
            {
                Pixel(steep ? new Point(y, x) : new Point(x, y), pixelSide);
                y += gradient;
            }
        }

        public static void Grid(int height, int width, int dy, int dx, int pixelSide)
        {
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Lines);

            for (int i = 0, j = 0; j < dx; i += pixelSide, j++)
            {
                GL.Vertex2(i, 0);
                GL.Vertex2(i, height);
            }

            for (int i = 0, j = 0; j < dy; i += pixelSide, j++)
            {
                GL.Vertex2(0, i);
                GL.Vertex2(width, i);
            }
            GL.End();
        }
    }
}
