using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    public class Board
    {
        public CircularLinkedList<Position> instance = new CircularLinkedList<Position>();
        public PositionAggregate allPosition = new PositionAggregate();

        public void construction()
        {
            for (int i=0;i<=39;i++)
            {
                Position temp = new Position(" ", i);
                temp.type = "Case";
                if(i==10)
                {
                    temp.type = "Prison";
                }
                if(i==30)
                {
                    temp.type = "Go to Prison";
                }
                
                
                    
   
                instance.Add(temp);
                allPosition.items.Add(temp);
            }
            
        }
        public void MoveOnBoard(Player p,Dice d1,Dice d2)
        {
            
            int num = d1.dice_f + d2.dice_f;

            for (int i=0;i< num;i++)
            {
                p.node_pos=p.node_pos.next;
            }
        }

        public void MoveToJail(Player p)
        {
            while (p.node_pos.data.index != 10)
            {
                p.node_pos = p.node_pos.next;
            }
        }

        public void Pos_iterator()
        {
            Iterator i = allPosition.CreateIterator();
            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
            
            Console.ReadKey();
            Console.WriteLine(" ");
        }

    }
}
