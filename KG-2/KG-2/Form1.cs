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
    public partial class Form1 : Form
    {

        Point p = new Point(0, 0);
        bool loaded = false;
        int height = 86, width = 136;
        int pixelSide = 5;
        private List<Square> squares = new List<Square>();
        private List<Point> tmp_points = new List<Point>();
        private List<Square> squaresRast = new List<Square>();
        private List<Point> tmp_pointsRast = new List<Point>();
        private int activeSquare=-1;

        public Form1()
        {
            InitializeComponent();
            glControl1.MouseWheel += new MouseEventHandler(glControl1_MouseWheel);
        }
        void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (pixelSide - 5 > 0)
                {
                    pixelSide -= 5;
                    glControl1.Height -= height;
                    glControl1.Width -= width;
                }
            }
            else
            {
                if (pixelSide + 5 < 100)
                {
                    pixelSide += 5;
                    glControl1.Height += height;
                    glControl1.Width += width;
                }
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           glControl1.Invalidate();
        }
        private void SetupViewport()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Верхний левый угол имеет кооординаты(0, 0)
            GL.Viewport(0, 0, w, h); // Использовать всю поверхность GLControl под рисование
        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.White);
            SetupViewport();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            timer1.Start();
        }
        private void glControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //добавление примитивов
            {
                if (chckbxMode.Checked)
                {
                    double dx = glControl1.Width/width, dy = glControl1.Height/height;

                    int x = (int) (e.X/dx), y = (int) ((glControl1.Height - e.Y)/dy);

                    p = new Point(x, y);
                    if (tmp_pointsRast.Count == 0)
                    {
                        tmp_pointsRast.Add(p);
                    }
                    else
                    {
                        tmp_pointsRast.Add(p);
                        squaresRast.Add(new Square(tmp_pointsRast[0], tmp_pointsRast[1]));
                        tmp_pointsRast.Clear();
                    }
                }
                else
                {
                    if (e.Button == MouseButtons.Left)//добавление примитивов
                    {
                        int x = e.X, y = glControl1.Height - e.Y;
                        if (tmp_points.Count == 1)//добавление нового квалрата
                        {
                            tmp_points.Add(new Point(x, y));
                            squares.Add(new Square(tmp_points[0], tmp_points[1]));
                            tmp_points.Clear();
                            lstbxSquares.Items.Add("Square №" + squares.Count.ToString());
                            activeSquare = squares.Count - 1;
                            lstbxSquares.SelectedIndex = activeSquare;
                        }
                        else//добавление новой точки 
                            tmp_points.Add(new Point(x, y));
                    }
                }
            }


        }
        
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;
            glControl1.SwapBuffers();
            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.PointSize(6);

            if (chckbxMode.Checked)
            {


                //рисование сетки
                SetupViewport();
                Draw.Grid(glControl1.Height, glControl1.Width, height, width, pixelSide);
                //рисование квадратов

                foreach (var square in squaresRast)
                {
                    Draw.Square(square, pixelSide);
                }
            }
            else
            {
                //отрисовка квадратов
                foreach (var square in squares)
                {
                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.PushMatrix();

                    GL.Translate(square.center.x, square.center.y, 0);
                    GL.Scale(square.GetZoom(), square.GetZoom(), 1);
                    GL.Rotate(square.GetAngle(), 0, 0, 1);
                    GL.Translate(-square.center.x, -square.center.y, 0);

                    GL.Begin(PrimitiveType.Quads);


                    GL.Color3(Color.Black);
                    foreach (var node in square.nodes)
                    {
                        GL.Color3(Color.Black);
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
            }

        }
        //public void DrawGrid()
        //{
            

        //    GL.Color3(Color.Black);
        //    GL.Begin(PrimitiveType.Lines);

        //    for (int i = 0, j = 0; j < width; i += pixelSide, j++)
        //    {
        //        GL.Vertex2(i, 0);
        //        GL.Vertex2(i, glControl1.Height);
        //    }

        //    for (int i = 0, j = 0; j < height; i += pixelSide, j++)
        //    {
        //        GL.Vertex2(0, i);
        //        GL.Vertex2(glControl1.Width, i);
        //    }
        //    GL.End();
        //}

        private void lstbxSquares_SelectedIndexChanged(object sender, EventArgs e)
        {

            var ind = lstbxSquares.SelectedIndices;
            if (ind.Count != 0)
            {
                activeSquare = lstbxSquares.SelectedIndex;
            }
        }

        private void btnRotateR_Click(object sender, EventArgs e)
        {

            if (activeSquare >= 0)
                squares[activeSquare].SetAngle(-360);
            
        }

        private void btnRitateL_Click(object sender, EventArgs e)
        {
            if (activeSquare >= 0)
                squares[activeSquare].SetAngle(360);
        }

        private void btnZoomL_Click(object sender, EventArgs e)
        {
            squares[activeSquare].SetZoom(0.2);
        }

        private void btnZoomS_Click(object sender, EventArgs e)
        {
            squares[activeSquare].SetZoom(-0.2);
        }
    }
}
