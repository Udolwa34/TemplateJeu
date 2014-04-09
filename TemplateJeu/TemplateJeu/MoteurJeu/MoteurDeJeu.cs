using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateJeu.MoteurJeu
{
    class MoteurDeJeu
    {
        public SpriteBatch spriteBatch;
        public GameTime gameTime;
        public ContentManager contentManager;
        public List<DispositionTouches> panelTouches;
        public List<SpriteFont> panelPolices; private List<string> strPanelPolices;
        public List<Texture2D> panelTextures; private List<string> strPanelTextures;

        //Constructeur
        public MoteurDeJeu(SpriteBatch spr, GameTime gm, ContentManager cm)
        {
            spriteBatch = spr;
            gameTime = gm;
            contentManager = cm;
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
        private void defineDispositionTouches()
        {
            panelTouches.Add(new DispositionTouches(Keys.Up, Keys.Down,Keys.Left,Keys.Right,
                                                    Keys.A,Keys.Z,Keys.E,Keys.Q,Keys.S,Keys.D));
            panelTouches.Add(new DispositionTouches(Keys.D5, Keys.D2, Keys.D1, Keys.D3,
                                                    Keys.NumLock, Keys.Divide, Keys.Multiply, Keys.D7, Keys.D8, Keys.D9));
        }
        private void definePolices()
        {
            strPanelPolices.Add("nomDeMaFont");

        }
        private void defineTextures()
        {
            strPanelTextures.Add("maTexture");
        }

        //Méthodes MonoGame
        public void LoadContent()
        {
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