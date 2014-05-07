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
     abstract class Menu : Ecran
    {
        protected List<Bouton> bnBox;
        protected List<Curseur> listCurseurs;

        public Menu(string nom, Rectangle position, string design)
            : base(nom,position,design)
        {
            bnBox = new List<Bouton>();
            listCurseurs = new List<Curseur>();
            fillBnBox();
            fillListCurseurs();
        }

        abstract public void navigation();

        abstract public void fillBnBox();
        abstract public void fillListCurseurs();
       
        override public void Update()
        {
            base.Update();
            foreach (Bouton bn in bnBox)
            {
                bn.Update();
            }
            foreach (Curseur Cur in listCurseurs)
            {
                Cur.Update();
            }
        }

        override public void Draw()
        {
            base.Draw();
            foreach (Bouton bn in bnBox)
            {
                bn.Draw();
            }
            foreach (Curseur Cur in listCurseurs)
            {
                Cur.Draw();
            }            
        }
    }
}