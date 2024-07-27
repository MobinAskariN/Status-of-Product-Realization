using Microsoft.AspNetCore.Mvc;
using GraphWithLabels.Models;
using System.Linq;

namespace GraphWithLabels.Controllers
{
    public class StationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var stationId = 1;
            var station = _context.station
                                  .FirstOrDefault(s => s.stationId == stationId);
            if (station != null)
            {
                ViewBag.StationName = station.stataionName;
            }
            else
            {
                ViewBag.StationName = "Station not found";
            }

            return View();
        }
    }
}
