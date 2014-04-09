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
     abstract class Menu : Ecran
    {
        protected List<Bouton> bnBox;
        protected List<Curseur> listCurseurs;

        public Menu(string nom, Rectangle position, Texture2D design)
            : base(nom,position,design)
        {

            bnBox = new List<Bouton>();
            listCurseurs = new List<Curseur>();
        }

       abstract public void navigation(KeyboardState kbs);  

       override public void Draw()
       {
            foreach (Bouton bn in bnBox)
            {
                bn.Draw();
            }
            foreach (Curseur Cur in listCurseurs)
            {
                Cur.Draw();
            }            
        }

        override public void Update()
        {
            foreach (Bouton bn in bnBox)
            {
                bn.Update();
            }
            foreach (Curseur Cur in listCurseurs)
            {
                Cur.Update();
            }
        }
    }
}