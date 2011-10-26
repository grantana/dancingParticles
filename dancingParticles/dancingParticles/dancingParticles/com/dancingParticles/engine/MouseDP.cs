using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;



namespace com.dancingParticles.engine
{
    class MouseDP
    {
        public Vector2 pos;
        public Texture2D texture;

        public MouseDP()
        {
            /** init ***/
        }
        public MouseDP(Texture2D texture, Vector2 pos)
        {
            this.texture = texture;
            this.pos = pos;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,pos, Color.White);
        }


    }
}
