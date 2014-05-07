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
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PileEcran screenManager;

        public Game1() 
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
            screenManager = new PileEcran();
            MenuSimple menuPrincipal = new MenuSimple("Menu",new Rectangle(0,0,Window.ClientBounds.Width,Window.ClientBounds.Height),"Menu");
            screenManager.empiler(menuPrincipal as Ecran);
        }

    
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MoteurDeJeu.InstanceMDJ.LoadContent(spriteBatch, Content);
        }

        protected override void UnloadContent()
        {
        }

    
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //   Exit();
            MoteurDeJeu.InstanceMDJ.kbState = Keyboard.GetState();           
            screenManager.getLast().Update();
            MoteurDeJeu.InstanceMDJ.OldKbState = MoteurDeJeu.InstanceMDJ.kbState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            spriteBatch.Begin();
            screenManager.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
