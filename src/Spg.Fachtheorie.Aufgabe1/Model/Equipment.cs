using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Aufgabe1.Model
{
    public class Equipment : ReservableItem
    {

        protected Equipment() { }

        public Equipment(string name, EquipmentTypes eq) : base(name)
        {
            EquipmentType = eq;
        }

        public EquipmentTypes EquipmentType { get; set; }

    }
}
