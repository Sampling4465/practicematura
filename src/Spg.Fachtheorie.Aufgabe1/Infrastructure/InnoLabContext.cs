using Microsoft.EntityFrameworkCore;
using Spg.Fachtheorie.Aufgabe1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Aufgabe1.Infrastructure
{
    public class InnoLabContext : DbContext
    {

        public DbSet<WorkPlace> WorkPlaces => Set<WorkPlace>();
        public DbSet<Equipment> Equipments => Set<Equipment>();
        public DbSet<InnolabUser> InnolabUsers => Set<InnolabUser>();
        public DbSet<ReservableItem> ReservableItems => Set<ReservableItem>();
        public DbSet<Reservation> Reservations => Set<Reservation>();

        public DbSet<ReservationItem> ReservationItems => Set<ReservationItem>();
        public DbSet<Room> Rooms => Set<Room>();



        public InnoLabContext()
        { }

        // TODO: Konstruktor korrigieren
        public InnoLabContext(DbContextOptions options) :base(options)
        {
        
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InnolabUser>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<ReservableItem>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<Equipment>().Property(e => e.EquipmentType).HasConversion(
            v => v.ToString(),
            v => (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), v));

             modelBuilder.Entity<Reservation>().Property(e => e.State).HasConversion(
            v => v.ToString(),
            v => (ReservationStates)Enum.Parse(typeof(ReservationStates), v));

        }
    }
}