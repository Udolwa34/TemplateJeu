#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace TemplateJeu
{
    class MenuPrincipal : Menu
    {
        public MenuPrincipal(string nom, Rectangle position, string design)
            : base(nom,position,design)
        {
        }

        public override void fillBnBox()
        {
            bnBox.Add(new Bouton("firstOne", new Rectangle(100, 100, 50, 25), "commencer"));
            bnBox.Add(new Bouton("Scond", new Rectangle(100, 150, 50, 25), "option"));
        }
        public override void fillListCurseurs()
        {
            listCurseurs.Add(new Curseur("pointeur", new Rectangle(65, 100, 25, 25)));
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Draw()
        {
            base.Draw();
        }

        public override void navigation(KeyboardState kbs)
        { 
            
        }

    }
}
