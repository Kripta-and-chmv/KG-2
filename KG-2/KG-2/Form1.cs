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
        public Form1()
        {
            InitializeComponent();
        }
        bool loaded = false;
        private List<Square> squares = new List<Square>();
        List<Point> tmp_points = new List<Point>();

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
                if (tmp_points.Count == 1)
                {
                    tmp_points.Add(new Point(x, y));
                    squares.Add(new Square(tmp_points[0], tmp_points[1]));
                    tmp_points.Clear();
                }
                else
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
            
            GL.Begin(PrimitiveType.Quads);
            foreach (var square in squares)
            {
                GL.Color3(Color.Black);
                foreach (var node in square.nodes)
                {
                    GL.Color3(Color.Black);
                    GL.Vertex2(node.x, node.y);
                }
            }
            GL.End();
            GL.Begin(PrimitiveType.Points);
            foreach (var pt in tmp_points)//отрисовка примитива
            {
                GL.Color3(Color.Violet);
                GL.Vertex2(pt.x, pt.y);
            }
            GL.End();
        }
    }
}
