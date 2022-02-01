using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    public class ConcreteStatePause : State
    {
        public override void Handle1(Player p1,Dice d1,Dice d2, Board plateau)
        {
            Console.WriteLine(p1.name);
            Console.Write("ConcreteStateB handles request1.");
        }

        
    }
}
