using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Aufgabe1.Model
{
    public class Reservation : BaseInterface<int>
    {

#pragma warning disable CS8618
        protected Reservation() { }

#pragma warning restore CS8618

        public Reservation(InnolabUser user, DateTime startOf, DateTime endOf)
        {
           
            User = user;
            this.startOf = startOf;
            this.endOf = endOf;
            State = ReservationStates.REQUESTED;
        }

        public int Id { get; private set; }

        public InnolabUser User { get; set; }

        [Required]
        public DateTime startOf { get; set; }

        [Required]
        public DateTime endOf { get; set; }

        public ReservationStates State { get; set; }

        public List<ReservationItem> Items { get; set; } = new();
    }
}
