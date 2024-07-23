namespace GraphWithLabels.Models
{
    public class Vertex
    {
        public int LabelIndex { get; set; }
        public int VertexIndex { get; set; }

        public Vertex(int labelIndex, int vertexIndex)
        {
            LabelIndex = labelIndex;
            VertexIndex = vertexIndex;
        }
    }
}
