using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.dancingParticles.engine
{
    /* Use this class to handle game states 
     */
    public class StateManager
    {
        //Current state
        public int state;

        public StateManager(int state)
        {
           
            this.state = state;
            Console.WriteLine("StateManager init: "+state);
        }
    }
}
