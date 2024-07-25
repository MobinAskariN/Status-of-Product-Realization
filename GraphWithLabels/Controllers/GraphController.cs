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
                new Label("1", 1),
                new Label("2", 1),
                new Label("3", 4),
                new Label("4", 4),
                new Label("5", 1)
            };

            // Add edges
            var edges = new List<(Vertex, Vertex)>
            {
                (labels[0].getVertices()[0], labels[1].getVertices()[0]),
                
                (labels[1].getVertices()[0], labels[2].getVertices()[0]),
                (labels[1].getVertices()[0], labels[2].getVertices()[1]),
                (labels[1].getVertices()[0], labels[2].getVertices()[2]),
                (labels[1].getVertices()[0], labels[2].getVertices()[3]),
                
                (labels[2].getVertices()[0], labels[3].getVertices()[0]),
                (labels[2].getVertices()[1], labels[3].getVertices()[1]),
                (labels[2].getVertices()[2], labels[3].getVertices()[2]),
                (labels[2].getVertices()[3], labels[3].getVertices()[3]),

                (labels[3].getVertices()[0], labels[4].getVertices()[0]),
                (labels[3].getVertices()[1], labels[4].getVertices()[0]),
                (labels[3].getVertices()[2], labels[4].getVertices()[0]),
                (labels[3].getVertices()[3], labels[4].getVertices()[0])
            };

            ViewBag.Labels = labels;
            ViewBag.Edges = edges;

            return View();
        }
    }
}
