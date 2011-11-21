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
    internal class Menu : Screen
    {


        Main main;

        public Menu(Texture2D back, Texture2D rect, Main main)
        {
            clickableElements = new List<Button>();
            this.back = back;
            this.rect = rect;
            this.main = main;
            //addButton(Properties.SCREEN_WITH - 200 + 10, 10, 50, 50, Properties.texturaBotonHome, 1);
            //addButton(Properties.SCREEN_WITH - 200 + 100, 10, 50, 50, Properties.texturaBotonReload, 2);
            addButton(Properties.SCREEN_WITH / 2 - 150, Properties.SCREEN_HEIGHT/2-50, 300, 50, Properties.texturaBotonHome, 1);
            addButton(Properties.SCREEN_WITH / 2 - 150, Properties.SCREEN_HEIGHT / 2 + 10, 300, 50, Properties.texturaBotonReload, 2);
            addButton(Properties.SCREEN_WITH - 240 + 160, 10, 50, 50, Properties.texturaBotonAyuda, 3);
        }

        public void Update(Vector2 pos, MouseState mouse, GamePadState gps, GameTime gameTime)
        {
           
            //check user Drag Drop Events
            if (mouse.LeftButton == ButtonState.Pressed || gps.Buttons.A == ButtonState.Pressed)
            {
                //CHECK BUTTONS
                int clickedID = getClickedID(new Vector2(pos.X, pos.Y));
                if (clickedID >= 0)
                {
                    if (clickedID == 1)
                    {
                        main.stateManager.loadNextScreen(2, 0, gameTime);
                    }
                    if (clickedID == 2)
                    {
                        main.stateManager.loadNextScreen(4, 0, gameTime);
                    }
                    if (clickedID == 3)
                    {
                        main.lastState = 1;
                        main.stateManager.loadNextScreen(5, 0, gameTime);
                    }
                     
                    Console.WriteLine("BUTTON PRESSED: clickedID: "+clickedID);
                    //APACURRO BOTONES 
                }
               
            }
        

        }

        public void Reset()
        {
           
        }

       


        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 pos = new Vector2(0, 0);
            spriteBatch.Draw(back, pos, Color.White);
            //Draw buttons in case we have any
            foreach (Button button in clickableElements)
            {
               //button.drawTexture(spriteBatch);
                if (button.ID == 3) button.drawTexture(spriteBatch);

            }

            //DRAW UI EXTRA ELEMENTS

        }
    }
}
