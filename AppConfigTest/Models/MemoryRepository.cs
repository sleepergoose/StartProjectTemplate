using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppConfigTest.Models;

namespace AppConfigTest.Models
{
    public class MemoryRepository : IRepository
    {
        private Dictionary<int, Reservation> items;
        private static int counter = 0;
        public int Counter { get { return counter; } }
        public MemoryRepository()
        {
            items = new Dictionary<int, Reservation>();
            counter++;
            new List<Reservation>()
            {
                new Reservation { ClientName = "Scarlet", Location = "Board Room"},
                new Reservation { ClientName = "David Maloon", Location = "Lecture Hall"},
                new Reservation { ClientName = "Mark Walberg", Location = "Theatre"}
            }.ForEach(p => AddReservation(p));
        }
        public Reservation this[int id]
        {
            get
            {
                return items[id];
            }
        }

        public IEnumerable<Reservation> Reservations => items.Values;

        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.ReservationId == 0)
            {
                int lastKey = items.Count - 1;
                reservation.ReservationId = ++lastKey;
            }
            items[reservation.ReservationId] = reservation;
            return reservation;
        }

        public void DeleteReservation(int id) => items.Remove(id);
        

        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);
    }
}
