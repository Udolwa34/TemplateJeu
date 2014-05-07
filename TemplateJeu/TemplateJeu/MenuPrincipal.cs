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
    class MenuPrincipal : MenuSimple
    {      
        public MenuPrincipal(string nom, Rectangle position, string design)
            : base(nom,position,design)
        {
            fillBnBox();
            fillListCurseurs();
        }
        public override void fillBnBox()
        {
            bnBox.Add(new Bouton("Menus/MenuPrincipal/BTN_Jouer", new Rectangle(260, 200, 308, 64), "MP_Jouer"));
            bnBox.Add(new Bouton("Menus/MenuPrincipal/BTN_Options", new Rectangle(260, 280, 308, 64), "MP_Options"));
            bnBox.Add(new Bouton("Menus/MenuPrincipal/BTN_Quitter", new Rectangle(260, 360, 308, 64), "MP_Quitter"));
        }
        public override void fillListCurseurs()
        {
            int indice = 0;
            listCurseurs.Add(new Curseur(MoteurDeJeu.InstanceMDJ.panelTextures[0], 
                                    new Rectangle(bnBox[indice].getPosition().X, bnBox[indice].getPosition().Y, 80,64),
                                    indice, -90, -10));
        }
    }
}
