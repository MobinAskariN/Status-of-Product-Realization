using System.Collections.Generic;

namespace GraphWithLabels.Models
{
    public class Label
    {
        public static int s_index = 0;
        public int index;
        public string name { get; }
        public List<Vertex> vertices { get; set; }

        public Label(String name)
        {
            this.index = s_index;
            s_index++;
            this.name = name;
            vertices = new List<Vertex>();
        }

        public void addVertex(Vertex v) { vertices.Add(v); }
        public int num_vertices() {  return vertices.Count; }
    }
}
