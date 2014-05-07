using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateJeu.MoteurJeu;

namespace TemplateJeu
{
    /// <summary>
    /// Exemple d'utilisation de la classe abstraite "Ecran Passif".
    /// Cet écran est un écran de présentation du studio. Une image statique apparait.
    /// L'écran passe au menu principal au bout d'un certain nombre de secondes OU de l'appuie sur la touche "OK" du premier joueur
    /// </summary>
    class EcranPresentationStudio : EcranPassif
    {
        //////////// Constructeur
        public EcranPresentationStudio(string nom, Rectangle position, string design, double valChangement = 20)
            : base(nom,position,design,valChangement)
        {
        }


        //////////// Méthodes dédiées
        public override void changeEcran()
        {
            base.setTimer(base.getTimer() + 0.1);

            //Passe si on appuie sur le bouton "OK"
            if ( base.getTimer() >= base.getValMaxTimer() || (MoteurDeJeu.InstanceMDJ.kbState.IsKeyDown(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheOK)
                && MoteurDeJeu.InstanceMDJ.OldKbState.IsKeyUp(MoteurDeJeu.InstanceMDJ.panelTouches[0].ToucheOK)))
            {
                if (getNom() == "LogoStudio")
                {
                    //Passe au menu principal et dépile cet écran de la liste.
                    EcranPassif LogoMono = new EcranPresentationStudio("LogoMono", new Rectangle(0, 0, MoteurDeJeu.InstanceMDJ.widthFenetre, MoteurDeJeu.InstanceMDJ.heightFenetre), "Menus/EcranDev2");
                    MoteurDeJeu.InstanceMDJ.screenManager.depiler();
                    MoteurDeJeu.InstanceMDJ.screenManager.empiler(LogoMono as Ecran);
                }
                else if (getNom() == "LogoMono")
                {
                    //Passe au menu principal et dépile cet écran de la liste.
                    MenuSimple menuPrincipal = new MenuSimple("Menu", new Rectangle(0, 0, MoteurDeJeu.InstanceMDJ.widthFenetre, MoteurDeJeu.InstanceMDJ.heightFenetre), "Menus/MenuPrincipal/MenuPrincipal");
                    MoteurDeJeu.InstanceMDJ.screenManager.depiler();
                    MoteurDeJeu.InstanceMDJ.screenManager.empiler(menuPrincipal as Ecran);
                }
            }
        }
    }
}
