using System.Linq.Expressions;

namespace GraphWithLabels.Models
{
    public class Vertex
    {
        public int labelIndex { get; set; }
        public int vertexIndex { get; set; }
        public int id { get; set; }
        public int doc_percent { get; set; }
        public string? vertexName { get; set; }
        public List<DocTypes> prepared_docTypes { get; set; }
        public List<DocTypes> unprepared_docTypes { get; set; }

        public Vertex(int labelIndex, string? vertexName)
        {
            this.labelIndex = labelIndex;
            this.vertexName = vertexName;
            doc_percent = 0;
            prepared_docTypes = new List<DocTypes>();
            unprepared_docTypes = new List<DocTypes>();
        }
        public Vertex(){}
        public Vertex Copy()
        {
            return new Vertex
            {
                id = this.id,
                labelIndex = this.labelIndex,
                vertexIndex = this.vertexIndex,
                vertexName = this.vertexName,
                prepared_docTypes = this.prepared_docTypes,
                unprepared_docTypes = this.unprepared_docTypes
            };
        }
    }
}
