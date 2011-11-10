﻿using System;
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
        

        /*****UI*****/
        public static Texture2D texturaUIBarras;
        public static Texture2D texturaUIFill1;
        public static Texture2D texturaUIFill2;


        /****BOTONES****/
        public static Texture2D texturaBotonHome;
        public static Texture2D texturaBotonReload;

        /*** Particulas ***/
        public static Texture2D texturaParticula;
        public static Texture2D texturaObjetivo;
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
        public static Texture2D texturaAtractor1;
        public static Texture2D TexturaAtractor1
        {
            get { return texturaAtractor1; }
            set { texturaAtractor1 = value;}
        }

        public static Texture2D texturaAtractor2;
        public static Texture2D TexturaAtractor2
        {
            get { return texturaAtractor2; }
            set { texturaAtractor2 = value; }
        }

        public static Texture2D texturaAtractor3;
        public static Texture2D TexturaAtractor3
        {
            get { return texturaAtractor3; }
            set { texturaAtractor3 = value; }
        }

        public static Texture2D texturaAtractor4;
        public static Texture2D TexturaAtractor4
        {
            get { return texturaAtractor4; }
            set { texturaAtractor4 = value; }
        }
        public static int sizeAtractor = 100;
    }
}
