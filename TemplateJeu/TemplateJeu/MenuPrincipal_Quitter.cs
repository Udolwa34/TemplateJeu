#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using TemplateJeu.MoteurJeu;
#endregion

namespace TemplateJeu
{
    class MenuPrincipal_Quitter : MenuSimple
    {
        public MenuPrincipal_Quitter(string nom, Rectangle position, string design)
            : base(nom,position,design)
        {
            fillBnBox();
            fillListCurseurs();
        }
        public override void fillBnBox()
        {
            bnBox.Add(new Bouton("Menus/MenuPrincipal/BTN_Jouer", new Rectangle(getPosition().X + 20, getPosition().X + 20, 20, 20), "MP_Quitter_Oui"));
            bnBox.Add(new Bouton("Menus/MenuPrincipal/BTN_Options", new Rectangle(getPosition().X + 60, getPosition().X + 20, 20, 20), "MP_Quitter_Non"));
        }
        public override void fillListCurseurs()
        {
            int indice = 0;
            listCurseurs.Add(new Curseur(MoteurDeJeu.InstanceMDJ.panelTextures[0], 
                                    new Rectangle(bnBox[indice].getPosition().X, bnBox[indice].getPosition().Y, 20,16),
                                    indice, -25, -3));
        }
    }
}
