using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MojaDdl
{

    public class MojaDdl
    {
       
    }
    public enum Tools
    {
        points = 1,
        segments = 2,
        triangle=3,
        foUr_angle=4,
        square=5,
        rectangle=6,
        circle=7,
        elipse=8,

    }
    
        public class Element
        {
            public Point p1, p2,p3,p4;
            public Tools figure_type;
            public int srednica = 40;
            public int sr=20;
            public int line_width;
            public Color draw_color;
            public Color q_color;
        }


    public class MM
    {
        public static void Set(int indeks, string Imie, string Nazwisko)
        {
            string text = indeks + "\t" + Imie + "\t" + Nazwisko + "\t" + DateTime.Now;
            Clipboard.SetText(text);

        }
    }
}

