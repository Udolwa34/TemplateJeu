using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateJeu
{
    abstract class Ecran
    {
        private Texture2D design;
        private Rectangle position;
        private bool print;
        private string nom;
        
        public Ecran(string nom, Rectangle position, Texture2D design)
        {
            this.nom = nom;
            this.position = position;
            this.design = design;
            print = true;
        }

        public void setPrint(bool print)
        {
            this.print = print;
        }
        public void setPrint()
        {
            if (print == true)
                print = false;
            else
                print = true;
        }
        public bool getPrint()
        {
            return print;
        }
        public string getNom()
        {
            return nom;
        }

        public Rectangle getPosition()
        {
            return position;
        }

        public void setPosition(Rectangle position)
        {
            this.position = position;
        }
        /*
        public void LoadContent()
        {         
        }
        public void UnloadContent()
        {
        }*/
        abstract public void Update();
        abstract public void Draw();

    }
}