using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    public class Context
    {
        // A reference to the current state of the Context.
        public State _state = null;

        public Context(State state)
        {
            this.TransitionTo(state);
        }

        // The Context allows changing the State object at runtime.
        public void TransitionTo(State state)
        {
            
            this._state = state;
            this._state.SetContext(this);
        }

        // The Context delegates part of its behavior to the current State
        // object.
        public void Request1(Player p1,Dice d1,Dice d2, Board plateau)
        {
            this._state.Handle1(p1,d1,d2,plateau);
        }

        
    }
}
