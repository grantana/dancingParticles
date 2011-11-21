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
using com.dancingParticles.gui.screens;

namespace dancingParticles
{
    /// <summary>
    /// This is the main type for your  game
    /// </summary>
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public StateManager stateManager;
        Texture2D screenSplashTexture, screenMenuTexture, screenPauseTexture, screenCreditsTexture, screenGameTexture, guiSelectorTexture, guiRectangeTexture, mouseTexture;

        /*** Pantallas ***/
        Menu screenMenu;
        Creditos screenCreditos;
        Juego juego;
        

        /***** UI ******/
        MouseDP mouse;
        Vector2 posMouse;
        

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

            /*** LOAD ASSETS ***/
            Properties.parallax_1 = Content.Load<Texture2D>("mock/gui/screens/parallax_1");
            Properties.parallax_2 = Content.Load<Texture2D>("mock/gui/screens/parallax_2");
            Properties.parallax_3 = Content.Load<Texture2D>("mock/gui/screens/parallax_3");
            Properties.TexturaParticula     = Content.Load<Texture2D>("mock/gui/particula");
            Properties.TexturaNave          = Content.Load<Texture2D>("mock/gui/nave");
            Properties.texturaAtractor1     = Content.Load<Texture2D>("mock/gui/Atractors");
            Properties.texturaAtractor2     = Content.Load<Texture2D>("mock/gui/Atractors1");
            Properties.texturaAtractor3     = Content.Load<Texture2D>("mock/gui/Atractors2");
            Properties.texturaAtractor4     = Content.Load<Texture2D>("mock/gui/Atractors4");
            Properties.texturaObjetivo      = Content.Load<Texture2D>("mock/gui/objetivo");
            Properties.texturaBotonHome     = Content.Load<Texture2D>("mock/gui/botones/botonHome");
            Properties.texturaBotonReload   = Content.Load<Texture2D>("mock/gui/botones/botonReload");
            Properties.texturaUIBarras      = Content.Load<Texture2D>("mock/gui/barras");
            Properties.texturaUIFill1       = Content.Load<Texture2D>("mock/gui/barrasLaserRelleno");
            Properties.texturaUIFill2       = Content.Load<Texture2D>("mock/gui/barrasRellenoObjetivo");

            screenSplashTexture    =   Content.Load<Texture2D>("mock/gui/screens/Splash");
            screenMenuTexture      =   Content.Load<Texture2D>("mock/gui/screens/Menu");
            screenCreditsTexture   =   Content.Load<Texture2D>("mock/gui/screens/Credits");
            screenGameTexture      =   Content.Load<Texture2D>("mock/gui/screens/GameScreen");
            screenPauseTexture     =   Content.Load<Texture2D>("mock/gui/screens/Pause");
            guiSelectorTexture     =   Content.Load<Texture2D>("mock/gui/Selector");
            guiRectangeTexture     =   Content.Load<Texture2D>("mock/gui/rect");
            mouseTexture           =   Content.Load<Texture2D>("mock/gui/cursor");
            // TODO: use this.Content to load your game content here
            screenMenu = new Menu(screenMenuTexture, guiRectangeTexture, this);
            screenCreditos = new Creditos(screenCreditsTexture, guiRectangeTexture, this);
            //screenMenu.addButton(Properties.SCREEN_WITH/2 - 120, 130, 200, 35);
            //screenMenu.addButton(Properties.SCREEN_WITH/2 - 120, 180, 200, 35);


            /*** init juego ***/
            juego = new Juego(screenGameTexture, guiRectangeTexture, this);
            mouse = new MouseDP(mouseTexture, Vector2.Zero);
            posMouse = new Vector2(Properties.SCREEN_WITH/2, Properties.SCREEN_HEIGHT/2);
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
                stateManager.loadNextScreen(1, 2, gameTime);
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

            /*** Alan: aqui puse el switch para saber si estoy en game,
             * para poder actualizar las partículas
             */
            switch (stateManager.state)
            {
                case 1:
                    updateMenuScreen(gameTime);
                    break;
                case 2:
                    updateGameScreen(gameTime);
                    break;
                case 3:
                   // updateCreditosScreen(gameTime);
                    break;
                case 4:
                    updateCreditosScreen(gameTime);
                    break;
                default:
                    //Console.WriteLine("state is not defined");
                    break;
            }



            base.Update(gameTime);

            //send over click events
           // if (MouseState.Equals(MouseState))

            //UPDATE MOUSE POS
            // check Control Input
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                posMouse.X += GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X * Properties.mouseSpeed;
                posMouse.X = MathHelper.Clamp(posMouse.X,0,Properties.SCREEN_WITH);
                posMouse.Y -= GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y * Properties.mouseSpeed;
                posMouse.Y = MathHelper.Clamp(posMouse.Y,0,Properties.SCREEN_HEIGHT);
                mouse.pos = posMouse;
            }
            else
            {
                mouse.pos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            }
        }
        
        private void updateGameScreen(GameTime gameTime)
        {
            /*** Hacer Update de Physics y cualquier cosa del juego ***/
            juego.Update(mouse.pos, Mouse.GetState(), GamePad.GetState(PlayerIndex.One), gameTime);
        }

        private void updateMenuScreen(GameTime gameTime)
        {
            /*** Hacer Update de Physics y cualquier cosa del juego ***/
            screenMenu.Update(mouse.pos, Mouse.GetState(), GamePad.GetState(PlayerIndex.One), gameTime);
        }

        private void updateCreditosScreen(GameTime gameTime)
        {
            /*** Hacer Update de Physics y cualquier cosa del juego ***/
            screenCreditos.Update(mouse.pos, Mouse.GetState(), GamePad.GetState(PlayerIndex.One), gameTime);
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
            mouse.Draw(spriteBatch);
            //any custom extra draw here
            spriteBatch.End();
        }

        protected void drawCreditosScreen()
        {
            spriteBatch.Begin();
            screenCreditos.Draw(spriteBatch);
            mouse.Draw(spriteBatch);
            //any custom extra draw here
            spriteBatch.End();
        }


        protected void drawGameScreen()
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            juego.Draw(spriteBatch);
            mouse.Draw(spriteBatch);
            spriteBatch.End();
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
                case 4:
                    drawCreditosScreen();
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
