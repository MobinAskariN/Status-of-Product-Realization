using Microsoft.AspNetCore.Mvc;
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
            int max_nv = 1;

            int stationId = 1;
            int previous_layerId;

            // stationId = 1
            Station? first_station = _context.getStation(stationId);
            Layer? first_layer = _context.getLayer(first_station.layerId);
            List<SectionTypeTreeSectionCharts> first_sectionTree 
                    = _context.getSectionTypeTreeSectionCharts(Int32.Parse(first_layer.sectionTypeId));
            TreeSectionCharts? first_treeSectionCharts = _context.getTreeSectionCharts(first_sectionTree.First().TreeSectionChart_ID);
            
            Label first_label = new Label(first_station.stationName);
            Vertex first_v = new Vertex(first_label.index, first_treeSectionCharts.SectionName);
            first_v.id = first_sectionTree.First().TreeSectionChart_ID;
            first_v.vertexIndex = 0;
            first_label.addVertex(first_v);
            labels.Add(first_label);

            if (first_station.requiredDocId != null)
            {
                Dictionary<int, int> required_doc = _context.required_doc(first_station.requiredDocId);

                foreach (Vertex v in first_label.vertices)
                {
                    List<TreeSectionChartDocuments> treeSectionChartDocuments
                        = _context.getTreeSectionChartDocuments(v.id);
                    foreach (TreeSectionChartDocuments TreeDocument in treeSectionChartDocuments)
                    {
                        Documents? document = _context.getDocument(TreeDocument.Document_ID);
                        if (required_doc.Keys.Contains(document.DOCTYPEID))
                        {
                            v.doc_percent += required_doc[document.DOCTYPEID];
                        }
                    }
                }
            }


            stationId++;
            previous_layerId = first_station.layerId;
            max_nv = Math.Max(max_nv, 1);

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
                    List<int> numbers = _context.extract_numbers(layer.sectionTypeId);

                    int number_of_vertices = 0;
                    foreach (int sectionType_ID in numbers)
                    {
                        List<SectionTypeTreeSectionCharts> sectionTypeTreeSectionCharts 
                                = _context.getSectionTypeTreeSectionCharts(sectionType_ID);
                        number_of_vertices += sectionTypeTreeSectionCharts.Count;

                        for (int i = 0; i <  sectionTypeTreeSectionCharts.Count; i++)
                        {
                            TreeSectionCharts? treeSectionCharts
                                = _context.getTreeSectionCharts(sectionTypeTreeSectionCharts.ElementAt(i).TreeSectionChart_ID);
                            Vertex v = new Vertex(current_label.index, treeSectionCharts.SectionName);
                            v.id = sectionTypeTreeSectionCharts.ElementAt(i).TreeSectionChart_ID;
                            current_label.addVertex(v);

                            bool has_set = false;
                            int j = 0;
                            foreach (Vertex u in labels.Last().vertices)
                            {
                                if (_context.is_child(v.id, u.id))
                                {
                                    if (has_set == false)
                                    {
                                        v.vertexIndex = j;
                                        has_set = true;
                                    }
                                    edges.Add((u, v));
                                }
                                j++;
                            }
                        }
                    }
                    max_nv = Math.Max(max_nv, number_of_vertices);
                }
                else // jaryan hamgera
                {
                    var layer = _context.getLayer(station.layerId);
                    List<int> numbers = _context.extract_numbers(layer.sectionTypeId);

                    int number_of_vertices = 0;
                    foreach (int sectionType_ID in numbers)
                    {
                        List<SectionTypeTreeSectionCharts> sectionTypeTreeSectionCharts
                                = _context.getSectionTypeTreeSectionCharts(sectionType_ID);
                        number_of_vertices += sectionTypeTreeSectionCharts.Count;

                        for (int i = 0; i < sectionTypeTreeSectionCharts.Count; i++)
                        {
                            TreeSectionCharts? treeSectionCharts
                                = _context.getTreeSectionCharts(sectionTypeTreeSectionCharts.ElementAt(i).TreeSectionChart_ID);
                            Vertex v = new Vertex(current_label.index, treeSectionCharts.SectionName);
                            v.id = sectionTypeTreeSectionCharts.ElementAt(i).TreeSectionChart_ID;
                            current_label.addVertex(v);

                            bool has_set = false;
                            int j = 0;
                            foreach (Vertex u in labels.Last().vertices)
                            {
                                if (_context.is_parent(u.id, v.id))
                                {
                                    if (has_set == false)
                                    {
                                        v.vertexIndex = j;
                                        has_set = true;
                                    }
                                    edges.Add((u, v));
                                }
                                j++;
                            }
                        }
                    }
                    max_nv = Math.Max(max_nv, number_of_vertices);
                }

                if(station.requiredDocId != null) { 
                    Dictionary<int, int> required_doc = _context.required_doc(station.requiredDocId);
                    
                    foreach (Vertex v in current_label.vertices)
                    {
                        List<TreeSectionChartDocuments> treeSectionChartDocuments 
                            = _context.getTreeSectionChartDocuments(v.id);
                        foreach (TreeSectionChartDocuments TreeDocument in treeSectionChartDocuments)
                        {
                            Documents? document = _context.getDocument(TreeDocument.Document_ID);
                            if (required_doc.Keys.Contains(document.DOCTYPEID))
                            {
                                v.doc_percent += required_doc[document.DOCTYPEID];
                            }
                        }
                    }
                }

                current_label.set_vertexIndex();
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
            foreach((Vertex, Vertex) e in edges)
                Console.WriteLine (e.Item1.id + " " + e.Item2.id);


            ViewBag.SvgWidth = labels.Count * 150 + 100;
            ViewBag.Svgheight = max_nv * 120 + 300;
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
