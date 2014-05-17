using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TemplateJeu.MoteurJeu;

namespace TemplateJeu
{
    class Bouton
    {
        private Texture2D design;
        private Rectangle position;
        private string nom;

        public Bouton(string _design, Rectangle _position, string _nom)
        {
            nom = _nom;
            position = _position;
            LoadContent(_design);
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

    
        public void LoadContent(string nomBn)
        {
            design = MoteurDeJeu.InstanceMDJ.contentManager.Load<Texture2D>(MoteurDeJeu.InstanceMDJ.CheminRessourcesTextures + nomBn);
        }
        public void UnloadContent()
        {
        }
        public void Update()
        {
        }
        public void Draw()
        {
            MoteurDeJeu.InstanceMDJ.spriteBatch.Draw(design, position, Color.White);
        }

        public void onClick()
        {
            string nom = this.getNom();
            if (nom == "MP_Jouer")
            {
                //Passe au menu choix personnages
                MenuDouble ChoixPersos = new MenuChoixPerso("Menu",new Rectangle(0,0,MoteurDeJeu.InstanceMDJ.widthFenetre, MoteurDeJeu.InstanceMDJ.heightFenetre),"Menu",10,7);
                MoteurDeJeu.InstanceMDJ.screenManager.empiler(ChoixPersos as Ecran);
            }
            if (nom == "MP_Quitter")
            {
                //Passe au menu choix personnages
                MoteurDeJeu.InstanceMDJ.screenManager.getLast().setPrint(true);
                MenuDouble ChoixPersos = new MenuChoixPerso("Menu", new Rectangle(0, 0, MoteurDeJeu.InstanceMDJ.widthFenetre, MoteurDeJeu.InstanceMDJ.heightFenetre), "Menu", 10, 7);
                MoteurDeJeu.InstanceMDJ.screenManager.empiler(ChoixPersos as Ecran);
            }
            else if (nom == "option")
            {
                MoteurDeJeu.InstanceMDJ.screenManager.depiler();
            }
        }
    }
}
