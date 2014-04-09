﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateJeu.MoteurJeu
{
    class DispositionTouches
    {
        public Keys Touche1;
        public Keys Touche2;
        public Keys Touche3;
        public Keys Touche4;
        public Keys Touche5;
        public Keys Touche6;

        public DispositionTouches(Keys tch1, Keys tch2, Keys tch3, Keys tch4, Keys tch5, Keys tch6)
        {
            Touche1 = tch1;
            Touche2 = tch2;
            Touche3 = tch3;
            Touche4 = tch4;
            Touche5 = tch5;
            Touche6 = tch6;
        }

        public void AssignerTouches(int numTouche, Keys newTouche)
        {
            Keys[] tabKeys = new Keys[6] { Touche1, Touche2, Touche3, Touche4, Touche5, Touche6 };
            tabKeys[numTouche - 1] = newTouche;  
        }
    }
}
