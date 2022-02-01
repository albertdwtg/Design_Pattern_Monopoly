using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    public class Player
    {
        public string name;
        public int prison_count = 0;
        public int double_count = 0;
        public bool inPrison=false;
        public int position_index=0;
        public bool turn;
        public Context context;
        public Node<Position> node_pos;

        public Player(string name, State concreteState)
        {
            this.name = name;
            this.context = new Context(concreteState);
        }

        public void roll(Dice d1,Dice d2)
        {
            Console.WriteLine("Roll the first dice");
            d1.roll_dice();
            d1.print_f();
            Console.WriteLine("Roll the second dice");
            d2.roll_dice();
            d2.print_f();

        }

        public bool isDouble(Dice d1,Dice d2)
        {
            bool rep = false;
            if(d1.dice_f==d2.dice_f)
            {
                rep = true;
                double_count += 1;
                
                
            }
            else
            {
                this.double_count = 0;
                
            }
            return rep;
        }
        public void Update_Position(Dice d1,Dice d2)
        {
            int sum = d1.dice_f + d2.dice_f;
            Console.WriteLine("You advance  "+sum + " positions");
            int temp = sum + this.position_index;
            int new_pos = temp;
            if(temp>39)
            {
                new_pos = temp - 40;
            }
            this.position_index = new_pos;
            

        }

        public void check_double_count()
        {
            if(double_count==3)
            {
                this.inPrison = true;
                this.position_index = 10;
            }
            if(this.inPrison==true && prison_count==3)
            {
                this.inPrison = false;
            }
        }

        public void prison_time(Dice d1,Dice d2,Board plateau)
        {
            Console.WriteLine(this.name + ", you are in jail ");
            Console.WriteLine("Roll the dices ");
            Console.ReadKey();
            this.roll(d1, d2);
            bool rep = isDouble(d1, d2);
            if(rep==true)
            {
                Console.WriteLine("You move forward");
                this.Update_Position(d1, d2);
                plateau.MoveOnBoard(this, d1, d2);
                this.Print_node();
                this.prison_count = 0;
                this.inPrison = false;
            }
            else
            {
                this.prison_count += 1;
                if(this.prison_count==3)
                {
                    Console.WriteLine("You move forward");
                    this.Update_Position(d1, d2);
                    plateau.MoveOnBoard(this, d1, d2);
                    this.Print_node();
                    this.prison_count = 0;
                    this.inPrison = false;
                }
                else
                {
                    Console.WriteLine("You stay in jail");
                    Console.WriteLine(" ");
                }
            }
            
        }

        public void Print_node()
        {
            Console.WriteLine("INDEX : " + this.node_pos.data.index);
            Console.WriteLine("TYPE : " + this.node_pos.data.type);

        }
        public string toString()
        {
            string rep = "";
            rep = "Name : " + this.name;
            rep+=", Position on the board : " + this.node_pos.data.index;
            rep+=", In jail : " + this.inPrison;
            return rep;
        }




    }
}
