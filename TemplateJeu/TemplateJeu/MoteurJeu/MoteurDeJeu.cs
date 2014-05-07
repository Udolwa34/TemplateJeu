using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace TemplateJeu.MoteurJeu
{
    class MoteurDeJeu
    {
        static private MoteurDeJeu instanceMDJ;

        static public MoteurDeJeu InstanceMDJ
        {
            get {
                if (instanceMDJ == null)
                    instanceMDJ = new MoteurDeJeu();
                return instanceMDJ;
            }
        }
        
        public SpriteBatch spriteBatch;
        public ContentManager contentManager;
        public KeyboardState kbState; public KeyboardState OldKbState;
        public List<DispositionTouches> panelTouches;
        public List<SpriteFont> panelPolices; private List<string> strPanelPolices;
        public List<Texture2D> panelTextures; private List<string> strPanelTextures;
        public string CheminRessourcesFont = "Polices/";
        public string CheminRessourcesTextures = "Textures/";

        //Constructeur
        private MoteurDeJeu()
        {
            panelTouches = new List<DispositionTouches>();
            panelPolices = new List<SpriteFont>();
            strPanelPolices = new List<string>();
            panelTextures = new List<Texture2D>();
            strPanelTextures = new List<string>();
            defineDispositionTouches();
            definePolices();
            defineTextures();
        }

        //Méthodes persos

        private void defineDispositionTouches() // Définit les touches à utiliser pour chacun des joueurs.
        {
            panelTouches.Add(new DispositionTouches(Keys.Up, Keys.Down,Keys.Left,Keys.Right,
                                                    Keys.A,Keys.Z,Keys.E,Keys.Q,Keys.S,Keys.D,
                                                    Keys.Enter,Keys.Escape));
            panelTouches.Add(new DispositionTouches(Keys.D5, Keys.D2, Keys.D1, Keys.D3,
                                                    Keys.NumLock, Keys.Divide, Keys.Multiply, Keys.D7, Keys.D8, Keys.D9,
                                                    Keys.PageUp, Keys.PageDown));
        }
        private void definePolices() //Definit le nom des ressources-polices à charger pour toute l'application
        {
            //strPanelPolices.Add(CheminRessourcesFont+"nomDeMaFont");
        }
        private void defineTextures() // Definit le nom des ressources-textures à charger pour toute l'application
        {
            strPanelTextures.Add(CheminRessourcesTextures+"leCurseur");
        }

        //Méthodes MonoGame
        public void LoadContent(SpriteBatch spr, ContentManager cm)
        {
            spriteBatch = spr;
            contentManager = cm;
            foreach (string pol in strPanelPolices)
            {
                panelPolices.Add(contentManager.Load<SpriteFont>(pol));
            }
            foreach (string tex in strPanelTextures)
            {
                panelTextures.Add(contentManager.Load<Texture2D>(tex));
            }
            //On efface les listes de String
            for (int i = 0; i < strPanelPolices.Count(); i++)
            {
                strPanelPolices.RemoveAt(i);
            }
            for (int i = 0; i < strPanelTextures.Count(); i++)
            {
                strPanelTextures.RemoveAt(i);
            }
        }
        public void UnloadContent()
        {
        }

        /*
        public void Update()
        {
        }
        public void Draw()
        {
        }*/
    }
}