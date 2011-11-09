using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using com.dancingParticles.gui;

namespace com.dancingParticles.gui
{
    public class Screen
    {
        public List<Button> clickableElements;
        public Texture2D back, rect;

        public Screen()
        {
            /** init ***/
        }
        public Screen(Texture2D back, Texture2D rect)
        {
            clickableElements = new List<Button>();
            this.back = back;
            this.rect = rect;
        }

        protected void init(Texture2D back, Texture2D rect)
        {
            /*** En caso que se necesite llamar por fuera ***/
            clickableElements = new List<Button>();
            this.back = back;
            this.rect = rect;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Vector2 pos = new Vector2(0, 0);
            spriteBatch.Draw(back, pos, Color.White);

            //Draw buttons in case we have any
            foreach (Button button in clickableElements)
            {
                button.drawRectangle(spriteBatch, rect);
            } 
        }

        //REGRESA EL ID DE LOS BOTONES SI NO TIENE REGRESA -1
        public int getClickedID(Vector2 inputClick)
        {
            //Draw buttons in case we have any
            foreach (Button button in clickableElements)
            {
                if (button.checkHit(inputClick))
                {
                    return button.ID;
                }
            } 
            return -1;
        }



        public void addButton(int posX, int posY, int width, int height, Texture2D texturaBT, int btID)
        {
            clickableElements.Add(new Button(posX, posY, width, height, texturaBT, btID));      
        }

        
    }
}
