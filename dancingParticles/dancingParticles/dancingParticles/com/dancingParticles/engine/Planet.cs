using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.dancingParticles.engine
{
    class Planet : Atractor
    {
        public Planet(Vector2 pos, int masa)
        {
            posicion = pos;
            mass = masa;
            textura = Properties.TexturaPlaneta;

            initWithMass();
        }
    }
}
