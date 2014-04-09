using Microsoft.Xna.Framework.Input;

namespace TemplateJeu.MoteurJeu
{
    class DispositionTouches
    {
        public Keys ToucheHaut, ToucheBas, ToucheGauche, ToucheDroite;
        public Keys Touche1, Touche2, Touche3, Touche4, Touche5, Touche6;

        public DispositionTouches(Keys tchH, Keys tchB, Keys tchG, Keys tchD,
            Keys tch1, Keys tch2, Keys tch3, Keys tch4, Keys tch5, Keys tch6)
        {
            ToucheHaut = tchH;
            ToucheBas = tchB;
            ToucheGauche = tchG;
            ToucheDroite = tchD;
            Touche1 = tch1;
            Touche2 = tch2;
            Touche3 = tch3;
            Touche4 = tch4;
            Touche5 = tch5;
            Touche6 = tch6;
        }

        public void AssignerTouches(int numTouche, Keys newTouche)
        {
            Keys[] tabKeys = new Keys[10] { ToucheHaut, ToucheBas, ToucheGauche, ToucheDroite,
                                          Touche1, Touche2, Touche3, Touche4, Touche5, Touche6 };
            tabKeys[numTouche - 1] = newTouche;  
        }
    }
}
