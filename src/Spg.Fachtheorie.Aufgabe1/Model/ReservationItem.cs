using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Aufgabe1.Model
{
    // TODO: Rich DomainModel implementieren
    public class ReservationItem: BaseInterface<int> 
    {
        public ReservationItem() { }
        public ReservationItem(Reservation reservation, ReservableItem reservable)
        {
            Reservation = reservation;
            Reservable = reservable;
        }

        public int Id { get; private set; }
        public Reservation Reservation { get; set; } = default!;
        public ReservableItem Reservable { get; set; } = default!;
    }
}
