using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.dancingParticles.engine
{
    public class Particle
    {
        /*** GUI ***/
        private Texture2D textura;
        private Vector2 position;
        private Rectangle rect;
        private Rectangle source;
        private Vector2 mitad; // Para el vector origen (centrarlo)


        private Vector2 velocity;
        private int mass;
        private float radio;

        /*** la masa es relativa al tamaño ***/

        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }

        public Vector2 Position { get { return position; } }

        public float Mass { get { return mass; } }


        public Particle(Vector2 pos, Vector2 direccion, int masa)
        {
            textura = Properties.TexturaParticula;


            this.position = pos;
            this.velocity = direccion;
            this.mass = masa;
            radio = mass / 2;
            rect = new Rectangle((int)this.position.X, (int)this.position.Y, mass, mass);
            source = new Rectangle(0, 0, textura.Width, textura.Height);

            /*** ajustar masa y Sprite ***/
            rect.Width = rect.Height = (int)mass;
            mitad = new Vector2(rect.Width/2, rect.Height/2);
        }

        public void Update()
        {
            /*** calcular su velocidad ***/
            position += velocity;
            rect.X = (int)(position.X - mitad.X); // porque el spritebatch es una nena y quiere rectangulos...
            rect.Y = (int)(position.Y - mitad.Y); // restar la mitad
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, rect, source, Color.FloralWhite, 0.0f, mitad, SpriteEffects.None, 1.0f);
        }
    }
}
