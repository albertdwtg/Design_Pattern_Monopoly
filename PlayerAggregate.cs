using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    public class PlayerAggregate : Aggregate
    {
        public List<Player> items = new List<Player>();
        public override Iterator CreateIterator()
        {
            return new PlayerIterator(this);
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
            set { items.Insert(index,items[index]); }
        }
    }
}
