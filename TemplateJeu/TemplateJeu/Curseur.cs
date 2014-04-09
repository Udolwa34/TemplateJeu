#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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