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
            bnBox.Add(new Bouton("commencer", new Rectangle(100, 100, 50, 25), "commencer"));
            bnBox.Add(new Bouton("option", new Rectangle(100, 150, 50, 25), "option"));
        }
        public override void fillListCurseurs()
        {
            int indice = 0;
            listCurseurs.Add(new Curseur(MoteurDeJeu.InstanceMDJ.panelTextures[0], bnBox[indice].defPositionCurseurFleche(-30, 0, 20, 20), indice));
        }
    }
}
