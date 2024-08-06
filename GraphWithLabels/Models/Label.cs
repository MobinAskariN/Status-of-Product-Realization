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

        public void addVertex(Vertex v)
        {
            vertices.Add(v);
        }

        public void set_vertexIndex()
        {
            List<Vertex> sortedVertices = vertices.OrderBy(v => v.vertexIndex).ToList();
            for (int i = 0; i < sortedVertices.Count; i++)
                sortedVertices[i].vertexIndex = i;
        }

        public int num_vertices() {  return vertices.Count; }
    }
}
