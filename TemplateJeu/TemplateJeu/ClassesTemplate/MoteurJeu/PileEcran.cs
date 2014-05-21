using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateJeu
{
    class PileEcran
    {
        private List<Ecran> Ecrans;

        public PileEcran() 
        {
            Ecrans = new List<Ecran>();
        }

        public Ecran getLast()
        {
            return Ecrans.Last();
        }

        public void empilerPrint(Ecran nvo)
        {        
            Ecrans.Add(nvo);
        }

        public void empiler(Ecran nvo)
        {
            getLast().setPrint(false);
            Ecrans.Add(nvo);
        }

        public void depiler()
        {
            if (Ecrans.Count() != 0)
            {
                Ecrans.RemoveAt(Ecrans.Count() - 1);
                if (Ecrans.Count() != 0)
                {
                    getLast().setPrint(true);
                }
            }
            
        }

        public void viderPile()
        {
            Ecrans.Clear();
        }

        public void toMenu()
        {
            while (Ecrans.Last().getNom() != "Menu")
            {
                depiler();
            }
        }

        public void Draw()
        {
            foreach (Ecran Scr in Ecrans)
                if (Scr.getPrint() == true)
                    Scr.Draw();
        }

        public void Update()
        {
            Ecrans.Last().Update();
        }
    }
}

