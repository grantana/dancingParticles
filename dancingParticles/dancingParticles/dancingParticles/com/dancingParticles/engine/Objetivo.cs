using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.dancingParticles.engine
{
    class Objetivo
    {
        private Texture2D textura;
        private Vector2 position;
        private int energia;
        private int radio; // tamaño de colision con objetivo

        public Vector2 Position { get { return position; } }

        public Objetivo(Vector2 pos, int energiaTarget)
        {
            this.position = pos;
            this.textura = Properties.texturaObjetivo;
            energia = 0;
            radio = Properties.radioObjetivo;
        }

        public void AddEnergia(int cantidad)
        {
            energia += cantidad;
            if (energia >= Properties.maxEnergia)
            {
                energia = Properties.maxEnergia;
                Console.WriteLine("Ya llené energía");
            }
            Console.WriteLine("Energia: " + energia);
        }

        public void Update()
        {
            // disminuir energia constantemente
            if (energia > 0)
            {
                energia--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle realPosition = new Rectangle( (int)(position.X - radio) , (int)(position.Y - radio), (int)(Properties.radioObjetivo * 2), (int)(Properties.radioObjetivo * 2));
            spriteBatch.Draw(textura, realPosition, Color.White);
        }
    }
}
