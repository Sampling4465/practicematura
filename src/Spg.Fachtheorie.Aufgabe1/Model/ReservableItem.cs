using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Aufgabe1.Model
{
    public class ReservableItem : BaseInterface<int>
    {
#pragma warning disable CS8618
        protected ReservableItem() { }

#pragma warning restore CS8618
        public int Id { get; private set; }

        public ReservableItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<ReservationItem> Items { get; set; } = new();
    
    }
}
