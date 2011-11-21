using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.dancingParticles.engine
{
    public class Atractor
    {
        /************************************
         * Aqui se pone divertido.
         * Hay que tomar en cuenta su posición, agregarle una masa
         * y calcular la distancia entre las partículas para
         * saber que tanto les afecta la gravedad de este objeto.
         * 
         * Este objeto no se mueve, sólo afecta las particulas
         * **********************************/

        /*** GUI ***/
        protected Texture2D textura;

        protected Rectangle rect;

        protected Vector2 posicion;
        protected int mass;

        protected float radio;

        public Vector2 Posicion { get { return posicion; } }
        public float Radio { get { return radio; } }
        public int Mass { get { return mass; } }



        public Atractor() { }
        public Atractor(Vector2 posicion, int masa)
        {
            this.posicion = posicion;
            this.mass = masa;



            //dependiendo de la masa usar texturas diferentes
            if (masa < 0)
            {
                textura = Properties.TexturaAtractor1;
            }
            else
            {
                textura = Properties.TexturaAtractor2;
            }



            this.init();

        }



        protected void init()
        {

            int _size = Properties.sizeAtractor;

            this.radio = _size / 2;



            rect = new Rectangle((int)posicion.X, (int)posicion.Y, _size, _size);

            setPosicion(posicion);

        }



        protected void initWithMass()
        {

            radio = Math.Abs(mass) / 2 * 0.3f;

            rect = new Rectangle((int)(posicion.X), (int)(posicion.Y), (int)radio * 2, (int)radio * 2);



            /*** ajustar masa y Sprite ***/

            setPosicion(posicion);

        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, rect, Color.White);
        }

        public void setPosicion(Vector2 nPosicion)
        {
            this.posicion = nPosicion;

            Console.WriteLine("Posicion: {" + rect.X + " , " + rect.Y + "}  Size: {" + rect.Width + " , " + rect.Width + "}");

            Console.WriteLine("Radio: " + radio);
            rect.X = (int)(posicion.X - radio);
            rect.Y = (int)(posicion.Y - radio);
        }
    }
}
