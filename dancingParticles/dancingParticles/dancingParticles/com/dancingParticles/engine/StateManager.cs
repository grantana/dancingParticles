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
        public bool activated, stageLoaded;
        //Current state
        public int state;
        private int nextState;
        private float startTime;
        private float timeToNextState;
        private float currentStateTicks;
        public float maxTicks; 



        public StateManager(int state)
        {
            this.state = state;
            activated = false;
            stageLoaded = false;
            Console.WriteLine("StateManager init: "+state);
        }

        /*
         * timeToNextState: set to a negative value in case you want to run the current state forever  
         * */
        public void loadNextScreen(int nextState, float timeToNextState, GameTime gameTime)
        {
            Console.WriteLine("loadNextScreen: " + nextState);
            startTime = gameTime.TotalGameTime.Seconds;
            this.nextState = nextState;
            this.timeToNextState = timeToNextState;
            maxTicks = timeToNextState * 70;
            currentStateTicks = 0;
            stageLoaded = false;
        }

        public void makeSwitch()
        {
            this.state = nextState;
            stageLoaded = true;
        }


        public void startInternalTimer(GameTime gameTime) 
        {
            Console.WriteLine("StateManager startInternalTimer: " + gameTime);
            activated = true;
            startTime = gameTime.TotalGameTime.Seconds;
        }

        /*
         * Tick stateManager and chage state if necessary to next stage 
         */
        public void tick(GameTime gameTime)
        {
            //Console.WriteLine("gameTime.ElapsedGameTime.Milliseconds: " + gameTime.TotalGameTime.Seconds);
            currentStateTicks++;
            if ((startTime + timeToNextState) < gameTime.TotalGameTime.Seconds)  
            {
                if (!stageLoaded)
                {
                    //Console.WriteLine("CHANGE STATE");
                    makeSwitch();
                }
            }
        }


        public float getStateTicks()
        {
            return currentStateTicks;
        }

       
    }
}
