using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    public class PositionAggregate : Aggregate
    {
        public List<Position> items = new List<Position>();
        public override Iterator CreateIterator()
        {
            return new PositionIterator(this);
        }
        // Get item count
        public int Count
        {
            get { return items.Count; }
        }
        // Indexer
        public object this[int index]
        {
            get { return items[index].toString(); }
            set { items.Insert(index, items[index]); }
        }
    }
}
