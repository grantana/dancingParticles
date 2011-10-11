using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using com.dancingParticles.engine;
using com.dancingParticles.gui;
using com.dancingParticles;

namespace dancingParticles
{
    /// <summary>
    /// This is the main type for your  game
    /// </summary>
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        StateManager stateManager;
        Texture2D screenSplashTexture, screenMenuTexture, screenPauseTexture, screenCreditsTexture, guiSelectorTexture, guiRectangeTexture;

        Screen screenMenu;

        public Main()
        {
            Console.WriteLine("Main init: ");
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth   = Properties.SCREEN_WITH;
            graphics.PreferredBackBufferHeight  = Properties.SCREEN_HEIGHT;
            Content.RootDirectory = "Content";
            stateManager = new StateManager(0);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch     =   new SpriteBatch(GraphicsDevice);
            screenSplashTexture    =   Content.Load<Texture2D>("mock/gui/screens/Splash");
            screenMenuTexture      =   Content.Load<Texture2D>("mock/gui/screens/Menu");
            screenCreditsTexture   =   Content.Load<Texture2D>("mock/gui/screens/Credits");
            screenPauseTexture     =   Content.Load<Texture2D>("mock/gui/screens/Pause");
            guiSelectorTexture     =   Content.Load<Texture2D>("mock/gui/Selector");
            guiRectangeTexture     =   Content.Load<Texture2D>("mock/gui/rect");
            // TODO: use this.Content to load your game content here
            screenMenu = new Screen(screenMenuTexture, guiRectangeTexture);
            screenMenu.addButton(Properties.SCREEN_WITH/2 - 120, 130, 200, 35);
            screenMenu.addButton(Properties.SCREEN_WITH/2 - 120, 180, 200, 35);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // TODO: Add your update logic here
            if (!stateManager.activated)
            {
                Console.WriteLine("starting gameTime: " + gameTime);
                stateManager.startInternalTimer(gameTime);
                stateManager.loadNextScreen(1, 1, gameTime);
            }
            else
            {
                stateManager.tick(gameTime);
                /*
                if (stateManager.stageLoaded)
                {
                    stateManager.loadNextScreen(stateManager.state+1, 2, gameTime);
                }
                 * */
            }
            base.Update(gameTime);

            //send over click events
        }


        protected void drawSplashScreen()
        {
            graphics.GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            Vector2 pos = new Vector2(0, 0);
            //Console.WriteLine(stateManager.getStateTicks() + ", " + stateManager.maxTicks + " :" + stateManager.getStateTicks() / (stateManager.maxTicks/5));
            spriteBatch.Draw(screenSplashTexture, pos, new Color(new Vector4(1, 1, 1, stateManager.getStateTicks()/ (stateManager.maxTicks/5) )    ));
            spriteBatch.End();
           // spriteBatch.Draw(splashLogo, new Vector2(0, 0), Color.White);
        }

        protected void drawMenuScreen()
        {
            spriteBatch.Begin();
            screenMenu.Draw(spriteBatch);
            //any custom extra draw here
            spriteBatch.End();
        }


        protected void drawGameScreen()
        {
            graphics.GraphicsDevice.Clear(Color.Yellow);
        }


        protected void drawGameOverScreen()
        {
            graphics.GraphicsDevice.Clear(Color.PaleGoldenrod);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //depending on state manager call different base draws
            switch (stateManager.state)
            {
                case 0:
                    drawSplashScreen();
                    break;
                case 1:
                    drawMenuScreen();
                    break;
                case 2:
                    drawGameScreen();
                    break;
                case 3:
                    drawGameOverScreen();
                    break;
                default:
                    Console.WriteLine("state is not defined");
                    break;
            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
