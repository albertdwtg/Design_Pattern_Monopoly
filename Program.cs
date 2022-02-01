using System;
using System.Collections.Generic;

namespace Final_Project_Cohen_Watrigant
{
    class Program
    {
        static void Main(string[] args)
        {


            Singleton s1 = Singleton.Instance;
            Board plateau = s1.plateau;
            Dice d1 = new Dice();
            Dice d2 = new Dice();
            Player p1 = new Player("Antoine",new ConcreteStatePlay());
            Player p2 = new Player("Albert",new ConcreteStatePause());

            Initialisation(p1, p2, plateau);

            switchRole(p1, p2, d1, d2,plateau);


        }
        static void Initialisation(Player p1,Player p2, Board plateau)
        {
            plateau.construction();
            p1.turn = true;
            p2.turn = false;
            p1.node_pos = plateau.instance.head;
            p2.node_pos = plateau.instance.head;

            Console.WriteLine("Before the beginning of the game, do you want to see the list of players and the list of positions on the board ?");
            Console.WriteLine("(0 if you want to pass, 1 if you want to see these lists)");
            int rep = checkInt(Console.ReadLine());
            if(rep==1)
            {
                Player_iter(p1,p2);
                plateau.Pos_iterator();
            }

            Console.WriteLine("The game will begin ");
            Console.WriteLine(p1.name + " will start");
            Console.WriteLine("");
            Console.ReadKey();
        }

        static void Player_iter(Player p1, Player p2)
        {
            PlayerAggregate allPlayers = new PlayerAggregate();
            allPlayers.items.Add(p1);
            allPlayers.items.Add(p2);
            Iterator i = allPlayers.CreateIterator();
            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
            Console.ReadKey();
        }


        static void switchRole(Player p1,Player p2,Dice d1,Dice d2,Board plateau)
        {
            bool end = false;
            while(end== false)
            {
                p1.context.TransitionTo(new ConcreteStatePlay());
                p1.turn = true;
                p1.context.Request1(p1, d1, d2,plateau);
                if(p1.turn==false)
                {
                    p2.context.TransitionTo(new ConcreteStatePlay());
                    p2.turn = true;
                    p2.context.Request1(p2,d1,d2,plateau);
                }
                Console.WriteLine(" ");
                Console.WriteLine("Do you want to stop the game ? : (0 if you want to stop, 1 if you want to continue)");
                int rep = checkInt(Console.ReadLine());
                if(rep==0)
                {
                    end = true;
                }
                Console.WriteLine(" ");
            }
        }
        public static int checkInt(string n)
        {
            bool isNumeric = int.TryParse(n, out int num);
            while(isNumeric==false || (num>1 || num<0))
            {
                Console.WriteLine("Please enter an integrer between 0 and 1");
                n = Console.ReadLine();
                isNumeric = int.TryParse(n, out num);
            }
            return num;
        }

        
    }
}
