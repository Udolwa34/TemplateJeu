#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TemplateJeu.MoteurJeu;

#endregion

namespace TemplateJeu
{
    class Curseur
    {
        private Texture2D design;
        private Rectangle position;
        private int indiceElement;
        private int decalageX;
        private int decalageY;

        public Curseur(Texture2D _design, Rectangle _position, int indice = 0, int _decalageX = 0, int _decalageY = 0)
        {
            design = _design;
            position = _position;
            indiceElement = indice;
            decalageX = _decalageX;
            decalageY = _decalageY;
            position.X += decalageX;
            position.Y += decalageY;
        }

        public Curseur(string _design, Rectangle _position, int indice = 0, int _decalageX = 0, int _decalageY = 0)
        {
            position = _position;
            LoadContent(_design);
            indiceElement = indice;
            decalageX = _decalageX;
            decalageY = _decalageY;
            position.X += decalageX;
            position.Y += decalageY;
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
        public void setPosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }
        public int getDecalageX()
        {
            return this.decalageX;
        }
        public void setDecalageX(int x)
        {
            decalageX = x;
        }
        public int getDecalageY()
        {
            return this.decalageY;
        }
        public void setDecalageY(int y)
        {
            decalageY = y;
        }


        public int getIndice()
        {
            return this.indiceElement;
        }
        public void setIndice(int newIndice)
        {
            indiceElement = newIndice;
        }

        public void LoadContent(string nomCur)
        {
            design = MoteurDeJeu.InstanceMDJ.contentManager.Load<Texture2D>(MoteurDeJeu.InstanceMDJ.CheminRessourcesTextures + nomCur);
        }
        /*
        public void UnloadContent()
        {
        }*/
        public void Update()
        {
        }
        public void Draw()
        {
            MoteurDeJeu.InstanceMDJ.spriteBatch.Draw(design, position, Color.White);
        }

    }

}