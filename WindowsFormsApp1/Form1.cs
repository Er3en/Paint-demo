using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MojaDdl;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MojaDdl.MojaDdl mdll = new MojaDdl.MojaDdl();
          //  mdll.MM.Set(140009, "Jakub", "Rybski");
         
            change_tool(Tools.points);
          
        }

        public string save;
       public int n_t;
        Point p1 = new Point(500,50);
        Point p2 = new Point(400,400);
        List<Element> element_list = new List<Element>();
        public int sr=20;
        public Color actuall_color = Color.Black;
        public Color bq_color = Color.Empty;
        public int line_witdh = 10;
        public int caseSwitch = 1;
        Tools actuall_tool = Tools.points;
        
        private void Button1_Click(object sender, EventArgs e)
        {
           

        }
    
        private void PlikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NarzędziaGłówneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
     
        private void KolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color_window = new ColorDialog();
            if(color_window.ShowDialog() == DialogResult.OK)
            {
                actuall_color = color_window.Color;
            }
        }

      


        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
          
            for (int i = 0; i < element_list.Count; i++)
            {
                Element draw = element_list[i];
                Pen pen = new Pen(actuall_color, line_witdh);

                if(draw.figure_type==Tools.points)
                e.Graphics.FillEllipse(Brushes.Black, draw.p1.X-(sr/2), draw.p1.Y-(sr/2), sr, sr);

                if (draw.figure_type == Tools.segments)
                e.Graphics.DrawLine(pen, draw.p1, draw.p2);

           
                if(draw.figure_type==Tools.triangle)
                {
                   
                        PointF point1 = new PointF(draw.p1.X, draw.p1.Y);
                        PointF point2 = new PointF(draw.p2.X, draw.p2.Y);
                        PointF point3 = new PointF(draw.p3.X, draw.p3.Y);
                        PointF[] curvePoints =
                        {
                        point1,
                        point2,
                        point3,
                        };

                        SolidBrush x = new SolidBrush(draw.q_color);
                        e.Graphics.FillPolygon(x, curvePoints);
                 
                        e.Graphics.DrawLine(pen, draw.p1, draw.p2);
                       e.Graphics.DrawLine(pen, draw.p2, draw.p3);
                        e.Graphics.DrawLine(pen, draw.p3, draw.p1);
                   

                }
           
                //  e.Graphics.dra

                if(draw.figure_type==Tools.foUr_angle)
                {
                    e.Graphics.DrawLine(pen, draw.p1, draw.p2);
                    e.Graphics.DrawLine(pen, draw.p2, draw.p3);
                    e.Graphics.DrawLine(pen, draw.p3, draw.p4);
                    e.Graphics.DrawLine(pen, draw.p4, draw.p1);

                    PointF point1 = new PointF(draw.p1.X, draw.p1.Y);
                    PointF point2 = new PointF(draw.p2.X, draw.p2.Y);
                    PointF point3 = new PointF(draw.p3.X, draw.p3.Y);
                    PointF point4 = new PointF(draw.p4.X, draw.p4.Y);
                    PointF[] curvePoints =
                    {
                        point1,
                        point2,
                        point3,
                        point4,
                        };

                    SolidBrush x = new SolidBrush(draw.q_color);
                    e.Graphics.FillPolygon(x, curvePoints);

                  
                }
                if (draw.figure_type == Tools.square)
                {
                    int x, y, a = 0;
                    x = Math.Abs(draw.p1.X - draw.p2.X);
                    y = Math.Abs(draw.p1.Y - draw.p2.Y);
                    a=(int)Math.Round(Math.Sqrt((x*x)+(y*y)));

                    draw.p2.X = draw.p1.X + a;
                    draw.p2.Y = draw.p1.Y;
                    draw.p3.X = draw.p2.X;
                    draw.p3.Y = draw.p2.Y+a;
                    draw.p4.X = draw.p1.X;
                    draw.p4.Y = draw.p1.Y + a;
                    e.Graphics.DrawLine(pen, draw.p1, draw.p2);
                    e.Graphics.DrawLine(pen, draw.p2, draw.p3);
                    e.Graphics.DrawLine(pen, draw.p3, draw.p4);
                    e.Graphics.DrawLine(pen, draw.p4, draw.p1);

                    PointF point1 = new PointF(draw.p1.X, draw.p1.Y);
                    PointF point2 = new PointF(draw.p2.X, draw.p2.Y);
                    PointF point3 = new PointF(draw.p3.X, draw.p3.Y);
                    PointF point4 = new PointF(draw.p4.X, draw.p4.Y);
                    PointF[] curvePoints =
                    {
                        point1,
                        point2,
                        point3,
                        point4,
                        };

                    SolidBrush d = new SolidBrush(draw.q_color);
                    e.Graphics.FillPolygon(d, curvePoints);
                }
                if (draw.figure_type == Tools.rectangle)
                {
                    int a= 0;
                    a = draw.p2.Y-draw.p1.Y;
                    draw.p4.Y = draw.p1.Y + a;
                    draw.p4.X = draw.p1.X;
                    draw.p3.X = draw.p2.X;
                    draw.p3.Y = draw.p2.Y - a;
                   
                    
                    e.Graphics.DrawLine(pen, draw.p1, draw.p3);
                    e.Graphics.DrawLine(pen, draw.p3, draw.p2);
                    e.Graphics.DrawLine(pen, draw.p4, draw.p1);
                    e.Graphics.DrawLine(pen, draw.p2, draw.p4);
                    PointF point1 = new PointF(draw.p1.X, draw.p1.Y);
                    PointF point2 = new PointF(draw.p3.X, draw.p3.Y);
                    PointF point3 = new PointF(draw.p2.X, draw.p2.Y);
                    PointF point4 = new PointF(draw.p4.X, draw.p4.Y);
                    PointF[] curvePoints =
                    {
                        point1,
                        point2,
                        point3,
                        point4,
                     };

                    SolidBrush d = new SolidBrush(draw.q_color);
                    e.Graphics.FillPolygon(d, curvePoints);
                }

                if (draw.figure_type == Tools.circle)
                {
                    int x, y ,z= 0;
                    x = draw.p2.X - draw.p1.X;
                    y = draw.p2.Y - draw.p1.Y;
                    z=(int)Math.Round(Math.Sqrt(x * x + y * y));
                    e.Graphics.DrawEllipse(pen, draw.p1.X, draw.p1.Y, z, z);
                    SolidBrush d = new SolidBrush(draw.q_color);
                    e.Graphics.FillEllipse(d, draw.p1.X, draw.p1.Y, z, z);

                }

                if (draw.figure_type == Tools.elipse)
                {
                    int x, y = 0;
                    x = draw.p2.X - draw.p1.X;
                    y = draw.p2.Y - draw.p1.Y;
                    e.Graphics.DrawEllipse(pen, draw.p1.X, draw.p1.Y, x, y);
                    SolidBrush d = new SolidBrush(draw.q_color);
                    e.Graphics.FillEllipse(d, draw.p1.X, draw.p1.Y, x, y);

                }
            }
        }
 
        public void change_tool(Tools newest)
        {
            actuall_tool = newest;
            this.Text = actuall_tool.ToString();
            toolStripButton1.Checked = actuall_tool == Tools.points;
            toolStripButton2.Checked = actuall_tool == Tools.segments;
            toolStripButton3.Checked = actuall_tool == Tools.triangle;
            toolStripButton4.Checked = actuall_tool == Tools.foUr_angle;
            toolStripButton6.Checked = actuall_tool == Tools.square;
            toolStripButton5.Checked = actuall_tool == Tools.rectangle;
            toolStripButton7.Checked = actuall_tool == Tools.circle;
            toolStripButton8.Checked = actuall_tool == Tools.elipse;
            if (newest ==Tools.triangle)
            {
                n_t = 0;
            }
            if (newest == Tools.foUr_angle)
            {
                n_t = 0;
            } 
        }

        private void ToolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }
        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
           // MojaDDL.Segment mdll = new MojaDDL.Segment();
           

        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.X + " ; " + e.Y;
            if(actuall_tool==Tools.segments)
            if(new_element!=null)
            {
                new_element.p2 = e.Location;
                panel1.Refresh();
            }

        }
        private void ToolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void StatusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void SzerokośćToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripTextBox1_Click(object sender, EventArgs e)
        {
            
        }
        Element new_element = null;
        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Text = "Panel_MouseUp";

            p1.X = e.X;
            p1.Y = e.Y;
            if (actuall_tool == Tools.segments)
            {
                new_element.p2 = e.Location;
                new_element = null;
            }
        
            if (actuall_tool == Tools.square)
            {
                new_element.p2 = e.Location;
                new_element = null;
            }
            if (actuall_tool == Tools.rectangle)
            {
                new_element.p2 = e.Location;
                new_element = null;
            }
            if (actuall_tool == Tools.circle)
            {
                new_element.p2 = e.Location;
                new_element = null;
            }
            if (actuall_tool == Tools.elipse)
            {
                new_element.p2 = e.Location;
                new_element = null;
            }
            panel1.Refresh();

    
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Text = "Panel_MouseDown";
            p2.X = e.X;
            p2.Y = e.Y;

            if (actuall_tool == Tools.points)
            {
                new_element = new Element();
                new_element.figure_type = Tools.points;
                new_element.draw_color = actuall_color;
                new_element.p1 = e.Location;
                element_list.Add(new_element);
            }


            if (actuall_tool == Tools.segments)
            {
                new_element = new Element();
                new_element.figure_type = Tools.segments;
                new_element.draw_color = actuall_color;
                new_element.p1 = e.Location;
                new_element.p2 = e.Location;
                element_list.Add(new_element);
            }

            if (actuall_tool == Tools.triangle)
            {
               
                if(n_t==0)
                {

                    new_element = new Element();
                    new_element.figure_type = Tools.triangle;
                    new_element.draw_color = actuall_color;
                    new_element.q_color= bq_color;

                    new_element.p1 = e.Location;
                    n_t++;
                }
               else  if (n_t == 1)
                {
                    new_element.p2 = e.Location;
                    n_t++;
                }
               else  if (n_t == 2)
                {

                    new_element.p3 = e.Location;
                    element_list.Add(new_element);
                    panel1.Refresh();
                    n_t=0;
                }

            }
            if(actuall_tool ==Tools.foUr_angle)
            {
                if (n_t == 0)
                {

                    new_element = new Element();
                    new_element.figure_type = Tools.foUr_angle;
                    new_element.draw_color = actuall_color;
                    new_element.q_color = bq_color;
                    new_element.p1 = e.Location;
                    n_t++;
                }
                else if (n_t == 1)
                {
                    new_element.p2 = e.Location;
                    n_t++;
                }
                else if (n_t == 2)
                {

                    new_element.p3 = e.Location;
                    n_t++;
                }
                else if(n_t==3)
                {
                    new_element.p4 = e.Location;
                    element_list.Add(new_element);
                    panel1.Refresh();
                    n_t = 0;

                }
            }
            if(actuall_tool==Tools.square)
            {

                new_element = new Element();
                new_element.figure_type = Tools.square;
                new_element.draw_color = actuall_color;
                new_element.q_color = bq_color;
                new_element.p1 = e.Location;
                new_element.p2 = e.Location;
                element_list.Add(new_element);

            }
            if (actuall_tool == Tools.rectangle)
            {

                new_element = new Element();
                new_element.figure_type = Tools.rectangle;
                new_element.draw_color = actuall_color;
                new_element.q_color = bq_color;
                new_element.p1 = e.Location;
                new_element.p2 = e.Location;
                element_list.Add(new_element);

            }

            if (actuall_tool == Tools.circle)
            {
                new_element = new Element();
                new_element.figure_type = Tools.circle;
                new_element.draw_color = actuall_color;
                new_element.q_color = bq_color;
                new_element.p1 = e.Location;
                new_element.p2 = e.Location;
                element_list.Add(new_element);
            }
            if (actuall_tool == Tools.elipse)
            {
                new_element = new Element();
                new_element.figure_type = Tools.elipse;
                new_element.draw_color = actuall_color;
                new_element.q_color = bq_color;
                new_element.p1 = e.Location;
                new_element.p2 = e.Location;
                element_list.Add(new_element);
            }

            panel1.Refresh();
         
        }




        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            change_tool(Tools.points);

        }


        private void ToolStripButton2_Click_1(object sender, EventArgs e)
        {

            change_tool(Tools.segments);
            //caseSwitch = 2;
            /*
            if (toolStripTextBox1.Text == "")
            {
                line_witdh = 5;

            }
            else
            {
                line_witdh = int.Parse(toolStripTextBox1.Text);
            }
            */

        }

        private void ToolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(toolStripTextBox1.Text== "" )
            {
                line_witdh = 7;

            }
            else
            {
                line_witdh = int.Parse(toolStripTextBox1.Text);
            }
            
        }
  
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            change_tool(Tools.triangle);
        }

        private void WyczyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }
            private void ŚrednicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripTextBox2_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text == "")
            {
                 sr= 20;
            }
            else
            {
               sr = int.Parse(toolStripTextBox2.Text);
            }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            change_tool(Tools.foUr_angle);
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            change_tool(Tools.square);
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            change_tool(Tools.rectangle);
        }

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            change_tool(Tools.circle);
        }

        private void ToolStripButton8_Click(object sender, EventArgs e)
        {
            change_tool(Tools.elipse);
        }

        private void ZapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
             int width = panel1.Size.Width;
                int height = panel1.Size.Height;

                Bitmap bm = new Bitmap(width, height);
                panel1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

            if(save =="")
            {
                bm.Save(@"C:\Desktop\TEST.bmp");
            }
            else
            {
                bm.Save(@save);
            }
               
           
        }

        private void WypełnienieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color_window = new ColorDialog();
            if (color_window.ShowDialog() == DialogResult.OK)
            {
                bq_color = color_window.Color;

            }
        }
        private void BrakWypełnienaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bq_color = Color.Empty;
        }

        private void ToolStripButton9_Click(object sender, EventArgs e)
        {
            MM.Set(140009, "Jakub", "Rybski");
        }

        private void ToolStripTextBox3_TextChanged(object sender, EventArgs e)
        {
            save = toolStripTextBox3.Text;
        }
    }
 

}
