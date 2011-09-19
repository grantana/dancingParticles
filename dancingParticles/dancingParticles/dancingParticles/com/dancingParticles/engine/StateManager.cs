using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;  
 


namespace com.dancingParticles.engine
{
    /* Use this class to handle game states 
     */
    public class StateManager
    {
        public bool activated;
        //Current state
        public int state;
        private int nextState;
        private float startTime;
        private float timeToNextState;


        public StateManager(int state)
        {
            this.state = state;
            activated = false;
            Console.WriteLine("StateManager init: "+state);
        }


        public void loadNextScreen(int nextState, float timeToNextState, GameTime gameTime)
        {
            this.nextState = nextState;
            this.timeToNextState = timeToNextState;
        }

        public void startInternalTimer(GameTime gameTime) 
        {
            Console.WriteLine("StateManager startInternalTimer: " + gameTime);
            activated = true;
            //startTime = gameTime. 
        }
    }
}
