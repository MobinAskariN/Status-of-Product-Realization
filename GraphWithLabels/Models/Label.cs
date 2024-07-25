using System.Collections.Generic;

namespace GraphWithLabels.Models
{
    public class Label
    {
        public static int s_index = 0;
        public int index;
        public string name { get; }
        private List<Vertex> vertices;

        public Label(String name, int numberOfVertices)
        {
            this.index = s_index;
            s_index++;
            this.name = name;
            vertices = new List<Vertex>();
            for (int i = 0; i < numberOfVertices; i++)
            {
                vertices.Add(new Vertex(index, i));
            }
        }

        public List<Vertex> getVertices(){ return vertices; }
        public void addVertex(Vertex v) { vertices.Add(v); }

    }
}
