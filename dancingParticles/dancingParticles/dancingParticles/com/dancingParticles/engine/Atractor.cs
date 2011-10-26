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
        private Texture2D textura;
        private Rectangle rect;
        
        private Vector2 posicion;
        private int mass;

        public Vector2 Posicion { get { return posicion; } }
        public int Mass { get { return mass; } }

        public Atractor(Vector2 posicion, int masa)
        {
            this.posicion = posicion;
            this.mass = masa;

            int _size = Properties.sizeAtractor;

            textura = Properties.texturaAtractor;
            rect = new Rectangle((int)posicion.X - _size / 2, (int)posicion.Y - _size / 2, _size, _size);
            /*** INTENTAR PONER EL TAMAÑO DEPENDIENTE DE LA MASA ***/
        }

        /*****************************************
         * Yo aqui quiero un update que haga que gire el mundo :/
         * **************************************/
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura,rect,Color.White);
        }

        public void setPosicion(Vector2 nPosicion)
        {
            this.posicion = nPosicion;
            int deltaX = Properties.sizeAtractor/2;
            int deltaY = Properties.sizeAtractor/2;
            rect.X = (int)posicion.X - deltaX;
            rect.Y = (int)posicion.Y - deltaY;
        }
    }
}
