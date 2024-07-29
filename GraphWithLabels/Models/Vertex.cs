namespace GraphWithLabels.Models
{
    public class Vertex
    {
        public int labelIndex { get; set; }
        public int vertexIndex { get; set; }
        public int id { get; set; }
        public int sanad1 { get; set; }
        public int sanad2 { get; set; }
        public int sanad3 { get; set; }


        public Vertex(int labelIndex, int vertexIndex)
        {
            this.labelIndex = labelIndex;
            this.vertexIndex = vertexIndex;
        }
    }
}
