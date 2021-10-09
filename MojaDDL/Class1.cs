using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MojaDDL
{
    
    public class Element
    {
        //public
         //Element()
         //  {


         //}
         //public Color my_color;
         //public Paint p1, p2;
    


    }
    public class PointX
    {
       
    }
    public class Segment
    {
       

        Point p1 = new Point(0, 0);
        Point p2 = new Point(0, 0);
        public int segment_witdh=10;
        List<Segment> segments = new List<Segment>();

        public void segment_p(object sender, EventArgs e)
        {

            Segment new_line = new Segment();
            new_line.p1 = e.Location;
            segments.Add(new_line);

        }
        
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
