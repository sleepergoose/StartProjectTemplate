using AppConfigTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppConfigTest.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private IRepository repository;

        public ReservationController(IRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservations;

        [HttpGet("{id}")]
        public Reservation Get(int id) => repository[id];

        [HttpPost]
        public Reservation Post([FromBody] Reservation res) => repository.AddReservation(new Reservation { ClientName = res.ClientName, Location = res.Location });

        [HttpPut]
        public Reservation Update([FromBody] Reservation res) => repository.UpdateReservation(res);

        [HttpDelete]
        public void Delete(int id) => repository.DeleteReservation(id);
    }
}
