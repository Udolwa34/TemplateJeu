using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateJeu
{
    class PileEcran
    {
        private List<long> Ecrans;

        public PileEcran() 
        {
            Ecrans = new List<long>();
        }

        public long getLast()
        {
            return Ecrans.Last();
        }

        public void empiler(long nvo)
        {
            Ecrans.Add(nvo);
        }

        public void depiler()
        {
            if (Ecrans.Count()!=0)
            Ecrans.RemoveAt(Ecrans.Count() - 1);
        }

        public void viderPile()
        {
            Ecrans.Clear();
        }

        public void toMenu()
        {
            while (Ecrans.Last().nom != "Menu")
            {
                depiler();
            }
        }

        public void draw()
        {
            foreach (long Scr in Ecrans)
                if (Scr.print == true)
                    Scr.draw();
        }

        public void update()
        {
            Ecrans.Last().update();
        }
    }
}

