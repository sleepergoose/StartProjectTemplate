using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppConfigTest.Models;

namespace AppConfigTest.Models
{
    public interface IRepository
    {
        int Counter { get; }
        IEnumerable<Reservation> Reservations { get; }
        Reservation this[int id] { get; }

        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
    }
}
