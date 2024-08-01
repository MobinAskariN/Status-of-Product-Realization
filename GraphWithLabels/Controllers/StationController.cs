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
            WITH Ancestors AS (
                SELECT ID, SectionName, ParentID
                FROM TreeSectionCharts
                WHERE ID = {0}
                UNION ALL
                SELECT t.ID, t.SectionName, t.ParentID
                FROM TreeSectionCharts t
                INNER JOIN Ancestors a ON t.ID = a.ParentID
            )
            SELECT ID, SectionName, ParentID FROM Ancestors WHERE ID = {1}", 3095, 3092)
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
