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
        bool loaded = false;
        private List<Square> squares = new List<Square>();
        private List<Point> tmp_points = new List<Point>();
        private int activeSquare=-1;

        public Form1()
        {
            InitializeComponent();
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
            if (e.Button == MouseButtons.Left)//добавление примитивов
            {
                int x = e.X, y = glControl1.Height - e.Y;
                if (tmp_points.Count == 1)//добавление нового квалрата
                {
                    tmp_points.Add(new Point(x, y));
                    squares.Add(new Square(tmp_points[0], tmp_points[1]));
                    tmp_points.Clear();
                    lstbxSquares.Items.Add("Square №" + squares.Count.ToString());
                    activeSquare = squares.Count-1;
                    lstbxSquares.SelectedIndex = activeSquare;
                }
                else//добавление новой точки 
                    tmp_points.Add(new Point(x, y));
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
