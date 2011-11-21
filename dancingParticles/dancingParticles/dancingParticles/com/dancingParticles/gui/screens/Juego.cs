using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using com.dancingParticles.gui;
using dancingParticles;
using com.dancingParticles.engine;
using Microsoft.Xna.Framework.Input;

namespace com.dancingParticles.gui.screens
{
    internal class Juego : Screen
    {
        /* Esta pantalla va a tener al juego, probablemente aqui se cargue algo del lector/parser
         * de niveles.
         * 
         * Para pruebas aqui voy a agregar particulas a lo tonto, gracias.
         */

        private Physics fisica;
        private Nave nave;
        private Boolean pressedFlag = false;
        private Atractor lastPressedAtractor;

        /*** Parallax effect ***/
        private Texture2D parallax_1;
        private Texture2D parallax_2;
        private Texture2D parallax_3;

        /*** offset que se mueve ***/
        private float posFondo_1;

        /*** var para la posicion del mouse ***/
        private Vector2 posMouse;
        private Main main;

        public Juego(Texture2D back, Texture2D rect, Main main)
        {
            this.main = main;
            clickableElements = new List<Button>();
            this.back = back;
            this.rect = rect;
            fisica = Physics.Instance;
            nave = new Nave();
            /****GUI****/
            addButton(Properties.SCREEN_WITH - 200 + 10, 10, 50, 50, Properties.texturaBotonHome, 1);
            addButton(Properties.SCREEN_WITH - 200 + 100, 10, 50, 50, Properties.texturaBotonReload, 2);
            posMouse = new Vector2(Properties.SCREEN_WITH/2, Properties.SCREEN_HEIGHT/2);
            parallax_1 = Properties.parallax_1;
            parallax_2 = Properties.parallax_2;
            parallax_3 = Properties.parallax_3;

            /*** Parallax ***/
            posFondo_1 = 0;


            setElements();
           
        }

        public void Update(Vector2 pos, MouseState mouse, GamePadState gps, GameTime gameTime)
        {
            nave.Update();
            fisica.Update();
            //RESET GAME OR WHAT EVER DEPENDING ON ENERGY LEVELS
            if (nave.energia <= 0)
            {
                Reset();
            }
            else if (fisica.acumEnergy >= 1)
            {
                Reset();//PASA AL SIGUIENTE NIVEL
            }

            //check user Drag Drop Events
            if (mouse.LeftButton == ButtonState.Pressed || gps.Buttons.A == ButtonState.Pressed)
            {
                //CHECK BUTTONS
                int clickedID = getClickedID(new Vector2(pos.X, pos.Y));
                if (clickedID >= 0)
                {
                    if (clickedID == 1)
                    {
                        main.stateManager.loadNextScreen(1, 0, gameTime);
                    }
                    if (clickedID == 2)
                    {
                        Reset();
                    }
                     
                    Console.WriteLine("BUTTON PRESSED: clickedID: "+clickedID);
                    //APACURRO BOTONES 
                }
                if (pressedFlag)
                {
                     lastPressedAtractor.setPosicion(new Vector2(pos.X, pos.Y));
                }

                Atractor pressedAtractor = fisica.getAtractorUnderMouse(new Vector2(pos.X, pos.Y));
                if (pressedAtractor != null && !pressedFlag)
                {
                    lastPressedAtractor = pressedAtractor;
                    //USER IS PRESSING PLANET
                    pressedFlag = true;
                   
                }
            }
            else
            {
                pressedFlag = false;
            }


        }

        public void Reset()
        {
            fisica.Reset();
            nave.Reset();
            setElements();
        }

        public void setElements()
        {

            nave.posicion.X = 70;
            nave.posicion.Y = 10;
            /*** DEBUG ***/
            fisica.agregarAtractor(new Vector2(350, 150), 600);
            fisica.agregarAtractor(new Vector2(700, 600), -300);
            fisica.agregarObjetivo(new Vector2(900, 500), Properties.maxEnergia);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            posFondo_1 = (posFondo_1 + 0.0015f) % (float)(Math.PI * 2);
            Vector2 pos = new Vector2((float)Math.Cos(posFondo_1), (float)Math.Sin(posFondo_1));

            //spriteBatch.Draw(back, Vector2.Zero, Color.White);

            spriteBatch.Draw(parallax_3, new Vector2(pos.X * 50 - 25, pos.Y * 50 - 25), Color.White);
            spriteBatch.Draw(parallax_2, new Vector2(pos.X * 24 - 12, pos.Y * 24 - 12), Color.White);
            spriteBatch.Draw(parallax_1, new Vector2(pos.X * 12 - 6, pos.Y * 12 - 6), Color.White);

            /*** PHYSICS ***/
            fisica.Draw(spriteBatch);
            nave.Draw(spriteBatch);

            //Draw buttons in case we have any
            foreach (Button button in clickableElements)
            {
                button.drawTexture(spriteBatch);
            }

            //DRAW UI EXTRA ELEMENTS
            spriteBatch.Draw(Properties.texturaUIBarras, Properties.barrasUIRect, new Color(1, 1, 1, 0.5f));
            //CALCULATE ENERGY RECT
            Rectangle energyRect            =  new Rectangle(Properties.barrasUIFill1Rect.X, Properties.barrasUIFill1Rect.Y + (Properties.barrasUIFill1Rect.Height-(int)(Properties.barrasUIFill1Rect.Height * nave.energia)), Properties.barrasUIFill1Rect.Width, (int)(Properties.barrasUIFill1Rect.Height * nave.energia));
            Rectangle energyTargetRect      = new Rectangle(Properties.barrasUIFill2Rect.X, Properties.barrasUIFill2Rect.Y + (Properties.barrasUIFill2Rect.Height - (int)(Properties.barrasUIFill2Rect.Height * fisica.acumEnergy)), Properties.barrasUIFill2Rect.Width, (int)(Properties.barrasUIFill2Rect.Height * fisica.acumEnergy));
            spriteBatch.Draw(Properties.texturaUIFill1, energyRect, new Color(1, 1, 1, 0.8f));
            spriteBatch.Draw(Properties.texturaUIFill2, energyTargetRect, new Color(1, 1, 1, 0.8f));

           

        }
    }
}
