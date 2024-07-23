using System.Collections.Generic;

namespace GraphWithLabels.Models
{
    public class Label
    {
        public int Index { get; set; }
        public List<Vertex> Vertices { get; set; }

        public Label(int index, int numberOfVertices)
        {
            Index = index;
            Vertices = new List<Vertex>();
            for (int i = 0; i < numberOfVertices; i++)
            {
                Vertices.Add(new Vertex(index, i));
            }
        }
    }
}
