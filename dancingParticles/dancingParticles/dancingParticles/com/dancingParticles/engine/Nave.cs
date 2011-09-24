using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.dancingParticles.engine
{
    public class Nave
    {
        /* Este es el emisor de partículas, no se bien todavía
         * hacía qué lado va a aventarlas dentro del juego, 
         * pero por el momento lo hará hacia la derecha
         */
        /*** GUI ***/
        private Texture2D textura;
        private Vector2 posicion;


        private Physics fisica;
        private Random random; // Pues para las cosas random, no?
        private Vector2 direccion; // Hacia donde apunta su "emisor"
        private float angulo = 0; // Dirección del emisor, el angulo
        private float fuerza = 2.5f; // Potencia con la que expulsa particulas

        public Nave()
        {
            fisica = Physics.Instance;
            random = new Random();
            direccion = calculaDireccion();
        }

        public void Update()
        {
            // Lanzar partículas
            Particle p = new Particle(direccion, random.Next(Properties.minSize, Properties.maxSize));
            fisica.agregarParticula(p);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw();
        }

        private Vector2 calculaDireccion()
        {
            /* tomar el angulo y la fuerza para regresar un vector */
            float _x = (float)(Math.Cos(angulo * Math.PI / 180)*fuerza);
            float _y = (float)(Math.Sin(angulo * Math.PI / 180)*fuerza);
            return new Vector2(_x, _y);
        }
    }
}
