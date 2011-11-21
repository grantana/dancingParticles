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
        public static double aleatoriedadParticulas = 0.05;
        public static Vector2[] GUI_SELECTOR_STATE1_POS = {new Vector2(100, 100), new Vector2(100, 200)};
        public static int maxEnergia = 100;
        public static int radioObjetivo = 100;
        public static Rectangle barrasUIRect = new Rectangle(10, SCREEN_HEIGHT-10-141, 150, 141);
        public static Rectangle barrasUIFill1Rect = new Rectangle(barrasUIRect.X+9, barrasUIRect.Y+9, 58, 117);
        public static Rectangle barrasUIFill2Rect = new Rectangle(barrasUIRect.X+83, barrasUIRect.Y+9, 58, 117);
        public static float startShipEnergy = 1;
        public static float startAcumEnergy = 0;
        public static float energyDelta = .0002f;
        public static float deltaAcumEnergy = .002f;
        public static float mouseSpeed = 15;

        /*** CURRENT LEVEL ***/
        public static int currentLevel = 0;

        /*****UI*****/
        public static Texture2D texturaUIBarras;
        public static Texture2D texturaUIFill1;
        public static Texture2D texturaUIFill2;
        public static Texture2D parallax_1;
        public static Texture2D parallax_2;
        public static Texture2D parallax_3;


        /****BOTONES****/
        public static Texture2D texturaBotonHome;
        public static Texture2D texturaBotonReload;
        public static Texture2D texturaBotonCerrar;
        public static Texture2D texturaBotonAyuda;

        /*** Particulas ***/
        public static Texture2D TexturaObjetivo;
        public static Texture2D TexturaParticula { get; set; }
        public static int maxSize = 20;
        public static int minSize = 2;

        /*** Nave ***/
        public static Texture2D TexturaNave { get; set; }

        /*** Planeta ***/
        public static Texture2D TexturaPlaneta { get; set; }

        /*** Atractor ***/

        public static Texture2D TexturaAtractor1 { get; set; }
        public static Texture2D TexturaAtractor2 { get; set; }
        public static Texture2D TexturaAtractor3 { get; set; }
        public static Texture2D TexturaAtractor4 { get; set; }
        public static int sizeAtractor = 80;
    }
}
