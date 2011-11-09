using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using com.dancingParticles.gui;
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

        public Juego(Texture2D back, Texture2D rect)
        {
            clickableElements = new List<Button>();
            this.back = back;
            this.rect = rect;
            fisica = Physics.Instance;
            nave = new Nave();
            /****GUI****/
            addButton(Properties.SCREEN_WITH - 200 + 10, 10, 50, 50, Properties.texturaBotonHome, 1);
            addButton(Properties.SCREEN_WITH - 200 + 100, 10, 50, 50, Properties.texturaBotonReload, 2);

            setElements();
           
        }

        public void Update(MouseState mouse)
        {
            nave.Update();
            fisica.Update();
            //check user Drag Drop Events
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                //CHECK BUTTONS
                int clickedID = getClickedID(new Vector2(mouse.X, mouse.Y));
                if (clickedID >= 0)
                {
                    if (clickedID == 2)
                    {
                        Reset();
                    }
                     
                    Console.WriteLine("BUTTON PRESSED: clickedID: "+clickedID);
                    //APACURRO BOTONES 
                }
                if (pressedFlag)
                {
                     lastPressedAtractor.setPosicion(new Vector2(mouse.X, mouse.Y));
                }

                Atractor pressedAtractor = fisica.getAtractorUnderMouse(new Vector2(mouse.X, mouse.Y));
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
            setElements();
        }

        public void setElements()
        {
           

            /*** DEBUG ***/
            fisica.agregarAtractor(new Vector2(350, 150), 600);
            fisica.agregarAtractor(new Vector2(700, 600), -300);
            fisica.agregarObjetivo(new Vector2(900, 500), Properties.maxEnergia);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 pos = new Vector2(0, 0);
            spriteBatch.Draw(back, pos, Color.White);

            /*** PHYSICS ***/
            fisica.Draw(spriteBatch);
            nave.Draw(spriteBatch);

            //Draw buttons in case we have any
            foreach (Button button in clickableElements)
            {
                button.drawTexture(spriteBatch);
            }
        }
    }
}
