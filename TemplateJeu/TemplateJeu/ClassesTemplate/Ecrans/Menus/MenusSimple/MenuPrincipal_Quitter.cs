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
            bnBox.Add(new Bouton("Menus/MenuPrincipal/BTN_Quit_Oui",
                new Rectangle(getPosition().X + 20, getPosition().Y + getPosition().Height / 2 - 16, 154, 32), "MP_Quitter_Oui"));
            bnBox.Add(new Bouton("Menus/MenuPrincipal/BTN_Quit_Non",
                new Rectangle(getPosition().X + getPosition().Width / 2 + 20, getPosition().Y + getPosition().Height / 2 - 16, 154, 32), "MP_Quitter_Non"));
        }
        public override void fillListCurseurs()
        {
            int indice = 0;
            listCurseurs.Add(new Curseur("Menus/MenuPrincipal/Curseur_BTN_MP", 
                                    new Rectangle(bnBox[indice].getPosition().X, bnBox[indice].getPosition().Y, 154, 32),
                                    indice, 0, 0));
        }
    }
}
