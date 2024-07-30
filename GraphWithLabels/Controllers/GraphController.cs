﻿using Microsoft.AspNetCore.Mvc;
using GraphWithLabels.Models;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

namespace GraphWithLabels.Controllers
{
    public class GraphController : Controller
    {

        private readonly DatabaseMethods _context;
        public GraphController(DatabaseMethods context)
        {
            _context = context;
        }

        public  IActionResult Index()
        {
            var labels = new List<Label>();
            var edges = new List<(Vertex, Vertex)>();

            int stationId = 1;
            int previous_layerId;

            // stationId = 1
            Station? first_station = _context.getStation(stationId);
            Layer? first_layer = _context.getLayer(first_station.layerId);
            List<SectionTypeTreeSectionCharts> first_sectionTree 
                    = _context.getSectionTypeTreeSectionCharts(Int32.Parse(first_layer.sectionTypeId));
            
            Label first_label = new Label(first_station.stationName);
            Vertex first_v = new Vertex(first_label.index, 0);
            first_v.id = first_sectionTree.First().TreeSectionChart_ID;
            first_label.addVertex(first_v);
            labels.Add(first_label);

            stationId++;
            previous_layerId = first_station.layerId;

            while (true) // stationId >= 2
            {
                var station = _context.getStation(stationId);
                if (station == null)
                    break;

                Label current_label = new Label(station.stationName);

                if(previous_layerId == station.layerId) // jaryan sabet
                {
                    current_label.vertices = labels.Last().vertices.Select(v => v.Copy()).ToList();
                    foreach (var v in current_label.vertices)
                        v.labelIndex = current_label.index;
                    
                    for(int i = 0; i < labels.Last().vertices.Count; i++)
                    {
                        edges.Add((labels.Last().vertices[i], current_label.vertices[i]));
                    }
                }
                else if(station.layerId > previous_layerId) // jaryan vagara
                {
                    var layer = _context.getLayer(station.layerId);
                    
                    string[] numberStrings = layer.sectionTypeId.Split(',');
                    List<int> numbers = new List<int>();
                    foreach (string numberString in numberStrings)
                    {
                        if (int.TryParse(numberString, out int number))
                        {
                            numbers.Add(number);
                        }
                        else
                        {
                            Console.WriteLine($"'{numberString}' is not a valid number.");
                        }
                    }
                    foreach (int sectionType_ID in numbers)
                    {
                        List<SectionTypeTreeSectionCharts> sectionTypeTreeSectionCharts 
                                = _context.getSectionTypeTreeSectionCharts(sectionType_ID);
                        for(int i = 0; i <  sectionTypeTreeSectionCharts.Count; i++)
                        {
                            TreeSectionCharts? treeSectionCharts
                                = _context.getTreeSectionCharts(sectionTypeTreeSectionCharts.ElementAt(i).TreeSectionChart_ID);
                            Vertex v = new Vertex(current_label.index , i);
                            v.id = sectionTypeTreeSectionCharts.ElementAt(i).TreeSectionChart_ID;
                            current_label.addVertex(v);

                            foreach (Vertex u in labels.Last().vertices)
                            {
                                if (treeSectionCharts.ParentID == u.id)
                                {
                                    edges.Add((u, v));
                                }
                            }
                        }
                        

                    }

                }
                else // jaryan hamgera
                {

                }



                labels.Add(current_label);
                previous_layerId = station.layerId;
                stationId++;
            }

            foreach (Label l in labels)
            {
                Console.WriteLine (l.name);
                foreach(Vertex u in l.vertices)
                {
                    Console.WriteLine("\t" + u.labelIndex);
                }
            }

            ViewBag.Labels = labels;
            ViewBag.Edges = edges;
            return View();
        }
    }
}





/*
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
*/
