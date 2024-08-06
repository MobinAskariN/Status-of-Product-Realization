using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphWithLabels.Models
{
    public class Station
    {
        public int stationId { get; set; }  // Maps to the primary key in your table
        public string stationName { get; set; }  // Maps to the stationName column
        public int layerId { get; set; }
        //public int requiredDocId { get; set; }
    }

    
    public class Layer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intLayerTypeId { get; set; }
        public string layerName { get; set; }
        public string sectionTypeId { get; set; }
        public int layerLevel { get; set; }
    }

    public class SectionTypes
    {
        public int ID { get; set; }
        public string TypeName {  get; set; }
        // color
    }

    [Keyless]
    [Table("SectionTypeTreeSectionCharts")]
    public class SectionTypeTreeSectionCharts
    {
        public int SectionType_ID { get; set; }
        public int TreeSectionChart_ID { get; set; }

    }

    [Table("TreeSectionCharts")]
    public class TreeSectionCharts
    {
        public int ID { get; set; }
        public string SectionName {  get; set; }
        public int? ParentID { get; set; }

    }
}
