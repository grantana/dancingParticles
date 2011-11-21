using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace com.dancingParticles.Levels
{
    public class Level
    {
        /*****************************************************
         * Aqui se carga el contenido de cada nivel:
         * 
         * Las posiciones de los attractors, nave, repulsores
         * y el objetivo.
         * 
         * Se puede poner también la magnitud del ángulo en 
         * el que se lanzan las partículas de la nave, la masa
         * de los atractores/repulsores, etc.
         * **************************************************/

        public String posicionNave; // x,y
        public float anguloNave;

        public List<xmlAttractor> attractors;
        public List<xmlPlanet> planetas;

        //public List<String> posicionRepulsores;

        public String posicionObjetivo;

        public Level() { }
    }

    public class xmlAttractor
    {
        public String posicion;
        public int masa;
    }

    public class xmlPlanet
    {
        public String posicion;
        public int masa;
    }
}
