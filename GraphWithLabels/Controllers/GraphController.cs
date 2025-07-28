using Microsoft.AspNetCore.Mvc;
using GraphWithLabels.Models;

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

            List<Station> stations = _context.getStations();
            Dictionary<int, Vertex> dic_id_v_parent = new Dictionary<int, Vertex>(); // keeps previous label vertieces
            Dictionary<int, Vertex> dic_id_v_label = new Dictionary<int, Vertex>(); // keeps current label vertieces
            int previous_layerId = -1;
            int previous_stationId = -1;


            foreach (Station station in stations)
            {
                List<StationNode> stationNodes;
                List<DocInfo> docInfos;
                if (previous_layerId == -1 || previous_layerId < station.layerId) // vagara
                {
                    stationNodes = _context.getStationNodes_div(station.stationId);
                    docInfos = _context.getDocInfos_div(station.stationId);
                }
                else if (previous_layerId == station.layerId) // sabet
                {
                    stationNodes = _context.getStationNodes_fix(station.stationId);
                    docInfos = _context.getDocInfos_fix(station.stationId);
                } 
                else // hamgara
                {
                    stationNodes = _context.getStationNodes_con(previous_stationId);
                    docInfos = _context.getDocInfos_con(previous_stationId);
                }
                Label label = new Label(station.stationName);
                int v_index = 0;
                max_nv = Math.Max(max_nv, stationNodes.Count);



                foreach (StationNode stationNode in stationNodes) // creating nodes
                {
                    if (!dic_id_v_label.ContainsKey(stationNode.NodeID))
                    {
                        Vertex v = new Vertex(label.index, stationNode.SectionName);
                        v.id = stationNode.NodeID;
                        v.vertexIndex = v_index;
                        dic_id_v_label.Add(v.id, v);
                        v_index++;
                    }
                }

                foreach (StationNode stationNode in stationNodes)// setting edges
                {
                    if(stationNode.ParentID != null && dic_id_v_parent.ContainsKey(stationNode.ParentID.Value))
                    {
                        edges.Add((dic_id_v_parent[stationNode.ParentID.Value], dic_id_v_label[stationNode.NodeID]));
                    }

                }


                foreach (DocInfo docInfo in docInfos) // setting ducuments
                {
                    DocTypes d = new DocTypes();
                    d.ID = docInfo.ReqDocTypeID;
                    d.precent = docInfo.Weight;
                    d.Name = docInfo.Name;
                    //if (dic_id_v_label.ContainsKey(docInfo.NodeID))
                    //{
                    if(docInfo.AppDocTypeID != null)
                    {
                        dic_id_v_label[docInfo.NodeID].prepared_docTypes.Add(d);
                        dic_id_v_label[docInfo.NodeID].doc_percent += docInfo.Weight;
                    }
                    else
                    {
                        dic_id_v_label[docInfo.NodeID].unprepared_docTypes.Add(d);
                    }
                    //}
                }

                foreach(Vertex v in dic_id_v_label.Values)
                {
                    label.addVertex(v);
                }

                labels.Add(label);

                dic_id_v_parent.Clear();
                dic_id_v_parent = new Dictionary<int, Vertex>(dic_id_v_label);
                dic_id_v_label.Clear();
                previous_layerId = station.layerId;
                previous_stationId = station.stationId;
            }


            ViewBag.SvgWidth = labels.Count * 150;
            ViewBag.Svgheight = max_nv * 140 + 50;
            ViewBag.Labels = labels;
            ViewBag.Edges = edges;
            return View();
        }
    }
}
