using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    public class Position
    {
        public string type;
        public int index;

        public Position(string type, int index)
        {
            this.type = type;
            this.index = index;
        }

        public string toString()
        {
            string rep = "Index : " + this.index;
            rep += ", Type : "+this.type;
            return rep;
        }
    }
}
