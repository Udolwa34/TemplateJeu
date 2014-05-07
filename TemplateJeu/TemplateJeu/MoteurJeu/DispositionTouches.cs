using Microsoft.Xna.Framework.Input;

namespace TemplateJeu.MoteurJeu
{
    class DispositionTouches
    {
        public Keys ToucheHaut, ToucheBas, ToucheGauche, ToucheDroite;
        public Keys Touche1, Touche2, Touche3, Touche4, Touche5, Touche6;
        public Keys ToucheOK, ToucheBack;

        public DispositionTouches(Keys tchH, Keys tchB, Keys tchG, Keys tchD,
            Keys tch1, Keys tch2, Keys tch3, Keys tch4, Keys tch5, Keys tch6,
            Keys tchOk, Keys tchBack)
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
            ToucheBack = tchBack;
            ToucheOK = tchOk;
        }

        public void AssignerTouches(int numTouche, Keys newTouche)
        {
            Keys[] tabKeys = new Keys[12] { ToucheHaut, ToucheBas, ToucheGauche, ToucheDroite,
                                            Touche1, Touche2, Touche3, Touche4, Touche5, Touche6,
                                            ToucheOK, ToucheBas };
            tabKeys[numTouche - 1] = newTouche;  
        }
    }
}
