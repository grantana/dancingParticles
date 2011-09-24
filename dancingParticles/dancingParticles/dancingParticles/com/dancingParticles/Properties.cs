using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;

namespace com.dancingParticles
{
    class Properties
    {
        public static int SCREEN_WITH   = 1280;
        public static int SCREEN_HEIGHT = 720;
        public static Vector2[] GUI_SELECTOR_STATE1_POS = {new Vector2(100, 100), new Vector2(100, 200)};

        /*** Particulas ***/
        public static Texture2D texturaParticula;
        public static Texture2D TexturaParticula
        {
            get { return texturaParticula; }
            set { texturaParticula = value; }
        }
        public static int maxSize = 20;
        public static int minSize = 2;

        /*** Nave ***/
        public static Texture2D texturaNave;
        public static Texture2D TexturaNave
        {
            set { texturaNave = value; }
            get { return texturaNave; }
        }

        /*** Atractor ***/
        public static Texture2D texturaAtractor;
        public static Texture2D TexturaAtractor
        {
            get { return texturaAtractor; }
            set { texturaAtractor = value;}
        }
        public static int sizeAtractor = 100;
    }
}
