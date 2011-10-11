using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using com.dancingParticles.gui;

namespace com.dancingParticles.gui
{
    class Screen
    {
        public List<Button> clickableElements;
        public Texture2D back, rect;
        public Screen(Texture2D back, Texture2D rect)
        {
            clickableElements = new List<Button>();
            this.back = back;
            this.rect = rect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 pos = new Vector2(0, 0);
            spriteBatch.Draw(back, pos, Color.White);

            //Draw buttons in case we have any
            foreach (Button button in clickableElements)
            {
                button.drawRectangle(spriteBatch, rect);
            } 
        }


        public void addButton(int posX, int posY, int width, int height)
        {
            clickableElements.Add(new Button(posX, posY, width, height));      
        }

        
    }
}
