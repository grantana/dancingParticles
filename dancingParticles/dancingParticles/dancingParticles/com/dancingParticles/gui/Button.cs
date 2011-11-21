//Author: Marco Gaviño


using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace com.dancingParticles.gui
{
    //Simple Button class for GUI elements
    public class Button
    {
        public int posX, posY, height, width, ID;

        private Rectangle rect;
        private Texture2D textura;
        
        public Button(int posX, int posY, int width, int height, Texture2D textura, int ID)
        {
            this.posX = posX;
            this.posY = posY;
            this.height = height;
            this.width = width;
            this.textura = textura;
            this.ID = ID;
            rect = new Rectangle(posX, posY, width, height);
        }



        public bool checkHit(Vector2 inputClick)
        {
            if (inputClick.X > posX && inputClick.X < posX + width && inputClick.Y > posY && inputClick.Y < posY + height)
                return true;
            return false;
        }

        public void drawRectangle(SpriteBatch spriteBatch, Texture2D rectTexture) 
        {
            spriteBatch.Draw(rectTexture, rect, Color.Red);
        }

        public void drawTexture(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, rect, Color.White);
        }




    }
}
