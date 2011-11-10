using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using com.dancingParticles.engine;

namespace com.dancingParticles.engine
{
    /* La voy a implementar como Singleton para
     * poderla instanciar en otras clases sin
     * perder su referencia  ;) -Alan
     */

    public  class Physics
    {
        private static Physics instance;
        private List<Particle> particulas;
        private List<Atractor> atractores;
        private Objetivo objetivo;
        public float acumEnergy;
        public Physics() { init(); }

        public static Physics Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Physics();
                }
                return instance;
            }
        }

        public void init()
        {
            /*** inicializar ***/
            particulas = new List<Particle>();
            atractores = new List<Atractor>();
            acumEnergy = Properties.startAcumEnergy;
        }

        public void agregarParticula(Particle p)
        {
            /*** agregar la particula a la lista ***/
            if (particulas.Count < 10000)
            {
                particulas.Add(p);
            }
        }

        public void agregarAtractor(Vector2 posicion, int masa)
        {
            atractores.Add(new Atractor(posicion,masa));
        }

        public void agregarObjetivo(Vector2 posicion, int energia)
        {
            objetivo = new Objetivo(posicion, energia);
        }


        public void Update()
        {
            /*** hacer update si la lista tiene algo ***/
            foreach (Particle p in particulas) { p.Update(); }

            /*** atractores ***/
            foreach (Atractor a in atractores)
            {
                foreach (Particle p in particulas)
                {
                    // revisar distancia y aplicar gravedad
                    gravitate(a, p);

                    // revisar que las partículas salgan de pantalla
                    checkEdge(p);
                }
                for (int i = 0; i < particulas.Count; i++)
                {
                    if (i >= particulas.Count) { return; }
                    Particle p = particulas[i];
                    if (gravitate(a, p) || checkEdge(p))
                    {
                        particulas.Remove(p);
                        i--;
                    }
                    if (targetImpact(objetivo, p))
                    {
                        particulas.Remove(p);
                        i--;
                        acumEnergy += Properties.deltaAcumEnergy;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            /*** atractores ***/
            foreach (Atractor a in atractores) { a.Draw(spriteBatch); }
            
            /*** hacer draw si la lista tiene algo ***/
            foreach (Particle p in particulas)
            {
                // Draw
                p.Draw(spriteBatch);
            }

            /*** draw objetivo ***/
            if (objetivo != null) { objetivo.Draw(spriteBatch); }
        }

        private bool gravitate(Atractor a, Particle p)
        {
            float dx = p.Position.X - a.Posicion.X;
            float dy = p.Position.Y - a.Posicion.Y;
            float distSQ = dx * dx + dy * dy;
            float dist = (float)Math.Sqrt(distSQ);
            float fuerza = a.Mass * p.Mass / distSQ;
            float ax = fuerza * dx / dist;
            float ay = fuerza * dy / dist;
            /*** sólo cambiar velocidad de la particula ***/
            Vector2 vel = p.Velocity;
            vel.X -= ax / p.Mass;
            vel.Y -= ay / p.Mass;
            p.Velocity = vel;

            /*** return true -> la particula choca en el objeto ***/
            if (dist <= a.Radio)
            {
                return true;
            }
            return false;
        }

        private bool targetImpact(Objetivo a, Particle p)
        {
            float dx = p.Position.X - a.Position.X;
            float dy = p.Position.Y - a.Position.Y;
            float distSQ = dx * dx + dy * dy;
            float dist = (float)Math.Sqrt(distSQ);
            if (dist <= Properties.radioObjetivo)
            {
                return true;
            }
            return false;
        }


         private bool checkEdge(Particle p)
        {
            /*** quitar la partícula si ya salió de pantalla ***/
            if (p.Position.X < 0 || p.Position.X > Properties.SCREEN_WITH
                || p.Position.Y < 0 || p.Position.Y > Properties.SCREEN_HEIGHT)
            {
                return true;
            }
            else return false;
        }


        public Atractor getAtractorUnderMouse(Vector2 mousePos)
        {
            //min distance from mouse to atractor
            float minDistance = Properties.sizeAtractor*.5f;

            foreach (Atractor a in atractores)
            {
                //get distance from mouse to attractor
                float dis = Vector2.Distance(a.Posicion, mousePos);
                if (dis <= minDistance)
                    return a;

            }
            return null;

        }


        public void Reset()
        {
            atractores.Clear();
            particulas.Clear();
            acumEnergy = Properties.startAcumEnergy;
        }


    }
}
