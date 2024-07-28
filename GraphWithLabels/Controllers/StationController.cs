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
            var intLayerTypeId = 1;
            var layer = _context.layer
                                .FirstOrDefault(s => s.intLayerTypeId == intLayerTypeId);
            if (layer != null)
            {
                ViewBag.StationName = layer.layerName;
            }
            else
            {
                ViewBag.StationName = "Station not found";
            }

            return View();
        }
    }
}
