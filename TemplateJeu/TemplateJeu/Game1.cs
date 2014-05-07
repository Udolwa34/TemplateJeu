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
        
        public Game1() 
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
            MoteurDeJeu.InstanceMDJ.widthFenetre = Window.ClientBounds.Width;
            MoteurDeJeu.InstanceMDJ.heightFenetre = Window.ClientBounds.Height;
            MenuPrincipal menuPrincipal = new MenuPrincipal("LogoStudio", new Rectangle(0, 0, MoteurDeJeu.InstanceMDJ.widthFenetre, MoteurDeJeu.InstanceMDJ.heightFenetre), "Menu");
            MoteurDeJeu.InstanceMDJ.screenManager.empiler(menuPrincipal as Ecran);
            //MenuDouble menuPrincipal = new MenuDouble("Menu",new Rectangle(0,0,Window.ClientBounds.Width,Window.ClientBounds.Height),"Menu",2,4);
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
            MoteurDeJeu.InstanceMDJ.screenManager.getLast().Update();
            MoteurDeJeu.InstanceMDJ.OldKbState = MoteurDeJeu.InstanceMDJ.kbState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            spriteBatch.Begin();
            MoteurDeJeu.InstanceMDJ.screenManager.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
