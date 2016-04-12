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
        private double dk = 50;
        private List<Square> squares = new List<Square>();
        private List<Point> tmp_points = new List<Point>();
        private int activeSquare=-1;

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }
        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (dk - 5 > 0)
                    dk -= 5;
            }
            else
                dk += 5;
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
            if (e.Button == MouseButtons.XButton1)
                dk += 5;
            if (e.Button == MouseButtons.XButton2)
                dk -= 5;

        }
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;
            glControl1.SwapBuffers();
            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.PointSize(6);
            double kx = 0, ky = 0;
            for (ky = 0; ky < glControl1.Height; ky += dk)
            {
                for (kx = 0; kx < glControl1.Width; kx += dk)
                {
                    GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
                    GL.Begin(PrimitiveType.Quads);
                    GL.Color3(Color.Black);
                    GL.Vertex2(kx, ky);
                    GL.Vertex2(kx + dk, ky);
                    GL.Vertex2(kx + dk, ky + dk);
                    GL.Vertex2(kx, ky + dk);
                    GL.End();

                }
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
