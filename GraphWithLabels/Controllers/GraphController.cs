using Microsoft.AspNetCore.Mvc;
using GraphWithLabels.Models;
using System.Collections.Generic;

namespace GraphWithLabels.Controllers
{
    public class GraphController : Controller
    {
        public IActionResult Index()
        {
            // Example from the image
            var labels = new List<Label>
            {
                new Label(5, 1),
                new Label(4, 1),
                new Label(3, 4),
                new Label(2, 4),
                new Label(1, 1)
            };

            // Add edges
            var edges = new List<(Vertex, Vertex)>
            {
                (labels[0].Vertices[0], labels[1].Vertices[0]),
                
                (labels[1].Vertices[0], labels[2].Vertices[0]),
                (labels[1].Vertices[0], labels[2].Vertices[1]),
                (labels[1].Vertices[0], labels[2].Vertices[2]),
                (labels[1].Vertices[0], labels[2].Vertices[3]),
                
                (labels[2].Vertices[0], labels[3].Vertices[0]),
                (labels[2].Vertices[1], labels[3].Vertices[1]),
                (labels[2].Vertices[2], labels[3].Vertices[2]),
                (labels[2].Vertices[3], labels[3].Vertices[3]),

                (labels[3].Vertices[0], labels[4].Vertices[0]),
                (labels[3].Vertices[1], labels[4].Vertices[0]),
                (labels[3].Vertices[2], labels[4].Vertices[0]),
                (labels[3].Vertices[3], labels[4].Vertices[0])
            };

            ViewBag.Labels = labels;
            ViewBag.Edges = edges;

            return View();
        }
    }
}
