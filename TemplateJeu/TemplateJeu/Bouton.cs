using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TemplateJeu
{
    class Bouton
    {
        private Texture2D design;
        private Rectangle position;
        private string nom;

        public Bouton(Texture2D _design, Rectangle _position, string _nom)
        {
            nom = _nom;
            design = _design;
            position = _position;
        }

        public string getNom()
        {
            return this.nom;
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

        
        public void LoadContent()
        {         
        }
        public void UnloadContent()
        {
        }
        public void Update()
        {
        }
        public void Draw()
        {
        }

        public void onClick()
        {
            string nom = this.getNom();
            /*if (nom == "Bouton1")
            {
            }*/
        }
    }
}

/*
(abstract) Bouton


+ onClick () :  (event, tout ça )
 */
