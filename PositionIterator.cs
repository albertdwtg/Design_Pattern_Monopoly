using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    class PositionIterator : Iterator
    {
        PositionAggregate aggregate;
        int current = 0;
        // Constructor
        public PositionIterator(PositionAggregate aggregate)
        {
            this.aggregate = aggregate;
        }
        // Gets first iteration item
        public override object First()
        {
            object ret = null;
            ret = aggregate[current];
            current += 1;
            return ret;
        }
        // Gets next iteration item
        public override object Next()
        {
            object ret = null;
            if (current < aggregate.Count)
            {
                ret = aggregate[current];
                current += 1;
            }
            return ret;
        }
        // Gets current iteration item
        public override object CurrentItem()
        {
            return aggregate[current];
        }
        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return current >= aggregate.Count;
        }
    }
}
