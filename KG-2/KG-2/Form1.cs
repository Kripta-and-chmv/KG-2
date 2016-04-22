using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace KG_2
{
    public partial class Form1 : Form
    {
        bool moveMode = false;
        Point p = new Point(0, 0);
        bool loaded = false;
        int height = 86, width = 136;
        int pixelSide = 5;
        private int dx = 0, dy=0; 
        private List<Square> squares = new List<Square>();
        private List<Point> tmp_points = new List<Point>();
        private List<Square> squaresRast = new List<Square>();
        private List<Point> tmp_pointsRast = new List<Point>();
        private int activeSquare=-1;
        private int countRastSquare = 0;
        private int countSquare = 0;
        private Bitmap bmpTex;

        public Form1()
        {
            InitializeComponent();
            glControl1.MouseWheel += new MouseEventHandler(glControl1_MouseWheel);
            

        }

        void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (chckbxPaintMode.Checked)//для растеризованных масштабирование сетки
            {
                if (e.Delta < 0)
                {
                    if (pixelSide - 5 > 0)
                    {
                        pixelSide -= 5;
                        glControl1.Height -= 5*height;
                        glControl1.Width -= 5*width;
                    }
                }
                else
                {
                    if (pixelSide + 5 < 200)
                    {
                        pixelSide += 5;
                        glControl1.Height += 5*height;
                        glControl1.Width += 5*width;
                    }
                }
            }
            else//для обычных примитивов масштабирование примитивов
            {
                if (e.Delta < 0)
                {
                    squares[activeSquare].SetZoom(-0.2);
                }
                else
                {
                    squares[activeSquare].SetZoom(0.2);
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

            GL.Enable(EnableCap.Texture2D);
            //Basically enables the alpha channel to be used in the color buffer
            GL.Enable(EnableCap.Blend);
            //The operation/order to blend
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            //Use for pixel depth comparing before storing in the depth buffer
            //GL.Enable(EnableCap.DepthTest);
        }

        private void glControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (!moveMode)) //добавление примитивов
            {
                if (chckbxPaintMode.Checked)
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
                        squaresRast.Add(new Square(tmp_pointsRast[0], tmp_pointsRast[1], chckbxPaintMode.Checked, pixelSide, chkbxFill.Checked) );
                        tmp_pointsRast.Clear();
                        countRastSquare++;
                        lstbxSquares.Items.Add("Square №" + countRastSquare.ToString());
                        activeSquare = squaresRast.Count - 1;
                        lstbxSquares.SelectedIndex = activeSquare;
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
                            squares.Add(new Square(tmp_points[0], tmp_points[1], chckbxPaintMode.Checked, pixelSide, chkbxFill.Checked));
                            tmp_points.Clear();
                            countSquare++;
                            lstbxSquares.Items.Add("Square №" + countSquare.ToString());
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
            if(chckbxColorOr.Checked || chckbxColorNOr.Checked)
                GL.Enable(EnableCap.ColorLogicOp);
            if (!(chckbxColorOr.Checked && chckbxColorNOr.Checked))
                GL.Disable(EnableCap.ColorLogicOp);
            glControl1.SwapBuffers();
            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.PointSize(6);

            if (chckbxPaintMode.Checked)
            {
                //рисование сетки
                SetupViewport();
                Draw.Grid(glControl1.Height, glControl1.Width, height, width, pixelSide);
                //рисование квадратов
                bool active = false;
                for(int i =0; i<squaresRast.Count; i++)
                {
                    if (i == activeSquare)
                        active = true;
                    Draw.RastSquare(squaresRast[i], pixelSide, active);
                    active = false;
                }
            }
            else
            {
                //отрисовка квадратов
                Draw.SimpleSquare(squares, tmp_points, activeSquare);

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (lstbxSquares.SelectedIndices.Count != 0)
                    if (!chckbxPaintMode.Checked)
                        squares[lstbxSquares.SelectedIndex].SetColor(colorDialog1.Color);
                    else
                        squaresRast[lstbxSquares.SelectedIndex].SetColor(colorDialog1.Color);
            }
        }

        private void chckbxMoveMode_CheckedChanged(object sender, EventArgs e)
        {
            moveMode = chckbxMoveMode.Checked;
        }

        private void chckbxPaintMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbxPaintMode.Checked)//растеризованные
            {
                chckbxMoveMode.Visible = false;
                chckbxMoveMode.Checked = false;
                groupBox1.Visible = false;
                label6.Visible = false;
                btnTex.Visible = false;
                lstbxSquares.Items.Clear();
                activeSquare = -1;
                for (int i = 0; i < squaresRast.Count; i++)
                {
                    lstbxSquares.Items.Add("Square №" + (i + 1).ToString());
                }
            }
            else//обычные примитивы
            {
                chckbxMoveMode.Visible = true;
                label6.Visible = true;
                btnTex.Visible = true;
                groupBox1.Visible = true;
                lstbxSquares.Items.Clear();
                activeSquare = -1;
                for (int i = 0; i < squares.Count; i++)
                {
                    lstbxSquares.Items.Add("Square №" + (i + 1).ToString());
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lstbxSquares.SelectedIndex != -1)
            {
                if (chckbxPaintMode.Checked)//удаление растеризованных
                {
                    squaresRast.Remove(squaresRast[lstbxSquares.SelectedIndex]);
                    lstbxSquares.Items.Remove(lstbxSquares.Items[lstbxSquares.SelectedIndex]);
                    activeSquare--;
                }
                else//удаление обычных примитивов
                {
                    squares.Remove(squares[lstbxSquares.SelectedIndex]);
                    lstbxSquares.Items.Remove(lstbxSquares.Items[lstbxSquares.SelectedIndex]);
                    activeSquare--;
                }
            }
        }

        private void chckbxColorOr_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbxColorOr.Checked)
            {
                GL.Enable(EnableCap.ColorLogicOp);
                GL.LogicOp(LogicOp.Or);
            }
        

        }

        private void chckbxColorNOr_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbxColorNOr.Checked)
            {
                GL.Enable(EnableCap.ColorLogicOp);
                GL.LogicOp(LogicOp.Nor);
            }
          
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            int x_offset = (int)e.X - dx;
            int y_offset = (int)e.Y - dy;
            dx = e.X;
            dy = e.Y;
            var ind = lstbxSquares.SelectedIndex;

            if ((e.Button == MouseButtons.Left) && (moveMode))
            {
                squares[ind].center.x += x_offset;
                squares[ind].center.y -= y_offset;
                foreach (var node in squares[ind].nodes)
                {
                    node.x += x_offset;
                    node.y -= y_offset;
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1=new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                squares[lstbxSquares.SelectedIndex].filename= openFileDialog1.FileName;
                
            }
        }

        private void btnZoomS_Click(object sender, EventArgs e)
        {
            squares[activeSquare].SetZoom(-0.2);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str =  "Рисование фигуры происходит по нажатию ЛКМ. 1 точка - определяет центр фигуры, 2 - радиус\n"+
                           "Имеется 2 режима: Рисование обычных фигур(по умолчанию), а также растеризованных.\n"+
                           "Color-выбор цвета для фигуры.\n" +
                         "Delete-удаление выбранного фигуры.\n" +
                         "Cancel-отменить текущий выбор.\n" +
                         "Mode of transportation-Вкл/выкл режима перемещение фигуры.\n" +
                         "Color mixing - выбор логической операции для смешивания цветов.\n" +
                         "Fill shapes-вкл/выкл закраску фигуры.\n" +
                        "Open - Загрузка текстуры(доступно для обычных фигур).\n"+
                        "Rotation - повотор фигуры вправо/влево.\n"+
                        "Scaling - масштабирование фигуры.\n";
            MessageBox.Show(str, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
