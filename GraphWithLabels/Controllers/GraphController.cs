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
            // maximum number of vertices in a label in set of labels.
            // it is used for setting proper height for svg container
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

            // setting doc informations for the first station
            if (first_station.requiredDocId != null)
            {
                // extract documents from a string. notice that it can be different according to the format that your string is written
                //        <id , precent>
                Dictionary<int, int> required_doc = _context.required_doc(first_station.requiredDocId);
                //        <id , is the doc prepared?>
                Dictionary<int, bool> prepared;

                foreach (Vertex v in first_label.vertices)
                {
                    prepared = _context.create_dic(required_doc);// create a dictionary with same keys as 'required_doc'
                    List<TreeSectionChartDocuments> treeSectionChartDocuments
                        = _context.getTreeSectionChartDocuments(v.id);
                    foreach (TreeSectionChartDocuments TreeDocument in treeSectionChartDocuments)
                    {
                        Documents? document = _context.getDocument(TreeDocument.Document_ID);
                        if (required_doc.Keys.Contains(document.DOCTYPEID))
                        {
                            v.doc_percent += required_doc[document.DOCTYPEID];
                            prepared[document.DOCTYPEID] = true;
                        }
                    }
                    foreach (var key in prepared.Keys)
                    {
                        DocTypes d = _context.getDocTypes(key);
                        d.precent = required_doc[key];
                        if (prepared[key] == true)
                            v.prepared_docTypes.Add(d);
                        else
                            v.unprepared_docTypes.Add(d);
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

                // setting doc informations
                if(station.requiredDocId != null) {
                    // extract documents from a string. notice that it can be different according to the format that your string is written
                    //        <id , precent>
                    Dictionary<int, int> required_doc = _context.required_doc(station.requiredDocId);
                    //        <id , is the doc prepared?>
                    Dictionary<int, bool> prepared;
                    
                    foreach (Vertex v in current_label.vertices)
                    {
                        prepared = _context.create_dic(required_doc);
                        List<TreeSectionChartDocuments> treeSectionChartDocuments 
                            = _context.getTreeSectionChartDocuments(v.id);
                        foreach (TreeSectionChartDocuments TreeDocument in treeSectionChartDocuments)
                        {
                            Documents? document = _context.getDocument(TreeDocument.Document_ID);
                            if (required_doc.Keys.Contains(document.DOCTYPEID))
                            {
                                v.doc_percent += required_doc[document.DOCTYPEID];
                                prepared[document.DOCTYPEID] = true;
                            }
                        }
                        foreach (var key in prepared.Keys) 
                        {
                            DocTypes d = _context.getDocTypes(key);
                            d.precent = required_doc[key];
                            if (prepared[key] == true)
                                v.prepared_docTypes.Add(d);
                            else
                                v.unprepared_docTypes.Add(d);
                        }
                    }
                }

                current_label.set_vertexIndex();
                labels.Add(current_label);
                previous_layerId = station.layerId;
                stationId++;
            }

            ViewBag.SvgWidth = labels.Count * 150;
            ViewBag.Svgheight = max_nv * 140 + 50;
            ViewBag.Labels = labels;
            ViewBag.Edges = edges;
            return View();
        }
    }
}
