using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    public class Dice
    {
        public int dice_f=0;

        public void roll_dice()
        {
            Random rdn = new Random();
            dice_f = rdn.Next(1, 7);
        }
        public void print_f()
        {
            Console.WriteLine("The face of the dice is : " + dice_f);
        }
    }
}
