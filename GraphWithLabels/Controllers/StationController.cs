using Microsoft.AspNetCore.Mvc;
using GraphWithLabels.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            var layer = _context.treeSectionChart
                .FromSqlRaw(@"
            WITH Descendants AS (
                SELECT ID, SectionName, ParentID
                FROM TreeSectionCharts
                WHERE ID = {0}
                UNION ALL
                SELECT t.ID, t.SectionName, t.ParentID
                FROM TreeSectionCharts t
                INNER JOIN Descendants d ON t.ID = d.ParentID
            )
            SELECT ID, SectionName, ParentID FROM Descendants WHERE ID = {1}", 3096, 3091)
            .ToList()
            .Any();
            if (layer == true)
            {
                ViewBag.StationName = "yes baby";
            }
            else
            {
                ViewBag.StationName = "Station not found";
            }

            return View();
        }
    }
}
