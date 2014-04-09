﻿#region Using Statements
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
    class Curseur
    {
        private Texture2D design;
        private Rectangle position;

        public Curseur(Texture2D _design, Rectangle _position)
        {
            design = _design;
            position = _position;
        }

        public Texture2D getDesign()
        {
            return this.design;
        }
        public Rectangle getPosition()
        {
            return this.position;
        }
        public void setPosition(Rectangle newPosition)
        {
            position = newPosition;
        }

        /*
        public void LoadContent()
        {         
        }
        public void UnloadContent()
        {
        }*/
        public void Update()
        {
        }
        public void Draw()
        {
        }

    }

}