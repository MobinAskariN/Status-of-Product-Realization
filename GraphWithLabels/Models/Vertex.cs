namespace GraphWithLabels.Models
{
    public class Vertex
    {
        public int labelIndex { get; set; }
        public int vertexIndex { get; set; }
        public int id { get; set; }
        public int doc_percent { get; set; }
        public string? vertexName { get; set; }


        public Vertex(int labelIndex, string? vertexName)
        {
            this.labelIndex = labelIndex;
            this.vertexName = vertexName;
            doc_percent = 100;
        }
        public Vertex() { }
        public Vertex Copy()
        {
            return new Vertex
            {
                id = this.id,
                labelIndex = this.labelIndex,
                vertexIndex = this.vertexIndex,
                vertexName = this.vertexName
            };
        }
    }
}
