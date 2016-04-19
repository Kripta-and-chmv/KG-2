﻿using System;
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
       
        public static void Pixel(Point node, double pixelSide, Color col)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(col);
            GL.Vertex2(pixelSide * node.x, pixelSide * node.y);
            GL.Vertex2(pixelSide * (node.x + 1), pixelSide * node.y);
            GL.Vertex2(pixelSide * (node.x + 1), pixelSide * (node.y + 1));
            GL.Vertex2(pixelSide * node.x, pixelSide * (node.y + 1));
            GL.End();
        }
        public static void RastSquare(Square sq, int pixelSide, bool active)
        {
            //отрисовка граней
            for (int i = 0; i < 4; i++)
            {
                int j = i + 1;
                if (j == 4) j = 0;
                    BresenhamsLine(sq.nodes[i], sq.nodes[j], pixelSide, sq.GetColor());
            }
            if (sq.filled)
                Fill(sq, pixelSide);
            //отрисовка вершин
            if(active)
                foreach (var node in sq.nodes)
                {
                    Point pixel = new Point(Math.Truncate(node.x), Math.Truncate(node.y ));
                    Color c = Color.Red;
                    if (sq.GetColor() == Color.Red)
                        c = Color.Blue;
                    Pixel(node, pixelSide, c);
                }
        }

        public static void SimpleSquare(List<Square> squares, List<Point> tmp_points, int activeSquare)
        {
            foreach (var square in squares)
            {
                if (square.filled)
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                else
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.PushMatrix();

                GL.Translate(square.center.x, square.center.y, 0);
                GL.Scale(square.GetZoom(), square.GetZoom(), 1);
                GL.Rotate(square.GetAngle(), 0, 0, 1);
                GL.Translate(-square.center.x, -square.center.y, 0);
                GL.Begin(PrimitiveType.Quads);

                GL.Color3(square.GetColor());
                foreach (var node in square.nodes)
                {
                    GL.Color3(square.GetColor());
                    GL.Vertex2(node.x, node.y);
                }
                GL.End();
                GL.PopMatrix();

            }
            //отрисовка буферных точек
            GL.Begin(PrimitiveType.Points);
            foreach (var pt in tmp_points)
            {
                GL.Color3(Color.Violet);
                GL.Vertex2(pt.x, pt.y);
            }
            GL.End();
            //отрисовка точек активного квадрата
            if (activeSquare >= 0)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.PushMatrix();
                GL.Translate(squares[activeSquare].center.x, squares[activeSquare].center.y, 0);
                GL.Scale(squares[activeSquare].GetZoom(), squares[activeSquare].GetZoom(), 1);
                GL.Rotate(squares[activeSquare].GetAngle(), 0, 0, 1);
                GL.Translate(-squares[activeSquare].center.x, -squares[activeSquare].center.y, 0);
                GL.Begin(PrimitiveType.Points);
                foreach (var node in squares[activeSquare].nodes)
                {
                    GL.Color3(Color.Violet);
                    GL.Vertex2(node.x, node.y);
                }
                GL.End();
                GL.PopMatrix();
            }
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
        }

        public static void BresenhamsLine(Point p0, Point p1, int pixelSide, Color col)
        {
            if (p0.x < p1.x)
            {
                if (p0.y <= p1.y)
                {
                    var y = p0.y;
                    for (var x = p0.x; x <= p1.x; x++)
                    {
                        Pixel(new Point(x, y), pixelSide, col);
                        y++;
                    }
                }
                else
                {
                    var y = p0.y;
                    for (var x = p0.x; x <= p1.x; x++)
                    {
                        Pixel(new Point(x, y), pixelSide, col);
                        y--;
                    }
                }
            }
            else
            {
                if (p0.y <= p1.y)
                {
                    var y = p0.y;
                    for (var x = p0.x; x >= p1.x; x--)
                    {
                        Pixel(new Point(x, y), pixelSide, col);
                        y++;
                    }
                }
                else
                {
                    var y = p0.y;
                    for (var x = p0.x ; x >= p1.x ; x--)
                    {
                        Pixel(new Point(x, y), pixelSide, col);
                        y--;
                    }
                }
            }
           }
        private static void Fill(Square sq, int pixelSide)
        {
            Point left = sq.nodes[0], top = sq.nodes[1], right = sq.nodes[2], bottom = sq.nodes[3];
            int k = 0;
            for (var x = left.x; x < right.x; x++)
            {
                if (x <= top.x)
                    k++;
                else
                    k--;
                for (var y = left.y - k+1; y < left.y + k; y++)
                {
                    Pixel(new Point(x, y), pixelSide, sq.GetColor());
                }
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
