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
        public MenuPrincipal(string nom, Rectangle position, Texture2D design)
            : base(nom,position,design)
        {
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
