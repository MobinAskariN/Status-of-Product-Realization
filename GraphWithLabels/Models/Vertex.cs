namespace GraphWithLabels.Models
{
    public class Vertex
    {
        public int labelIndex { get; set; }
        public int vertexIndex { get; set; }
        public int id { get; set; }
        public int doc_percent { get; set; }


        public Vertex(int labelIndex, int vertexIndex)
        {
            this.labelIndex = labelIndex;
            this.vertexIndex = vertexIndex;
            doc_percent = 100;
        }
        public Vertex() { }
        public Vertex Copy()
        {
            return new Vertex
            {
                id = this.id,
                labelIndex = this.labelIndex,
                vertexIndex = this.vertexIndex
            };
        }
    }
}
