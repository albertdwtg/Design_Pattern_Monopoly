using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    public class ConcreteStatePlay : State
    {
        public override void Handle1(Player p1,Dice d1,Dice d2,Board plateau)
        {
            // Console.WriteLine("ConcreteStatePlay handles request1.");
            if(p1.inPrison==true)
            {
                p1.prison_time(d1, d2,plateau);
                Console.WriteLine("Next turn ");
                Console.WriteLine(" ");
                p1.turn = false;
                this._context.TransitionTo(new ConcreteStatePause());
            }
            else
            {

                bool dbl = true;
                while(dbl==true && p1.double_count<3 && p1.position_index!=30)
                {
                    Console.WriteLine(p1.name + " is playing !");
                    p1.roll(d1, d2);
                    dbl=p1.isDouble(d1, d2);
                    p1.Update_Position(d1, d2);
                    plateau.MoveOnBoard(p1, d1, d2);
                    p1.Print_node();
                    Console.WriteLine(" ");
                    Console.ReadKey();
                }
                if(p1.position_index==30 || p1.double_count==3)
                {
                
                    Console.WriteLine("You are going to prison");
                    plateau.MoveToJail(p1);
                    p1.Print_node();
                    p1.position_index = 10;
                    p1.inPrison = true;
                    p1.double_count = 0;
                }
                Console.WriteLine("Next turn ");
                Console.WriteLine(" ");
                p1.turn = false;
                this._context.TransitionTo(new ConcreteStatePause());
            }
        }

        
    }
}
