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
            var intLayerTypeId = 1007;
            var layer = _context.sectionTypeTreeSectionChart
                           .Where(p => p.SectionType_ID == intLayerTypeId)
                           .ToList();
            if (layer != null)
            {
                ViewBag.StationName = layer.First().TreeSectionChart_ID;
            }
            else
            {
                ViewBag.StationName = "Station not found";
            }

            return View();
        }
    }
}
