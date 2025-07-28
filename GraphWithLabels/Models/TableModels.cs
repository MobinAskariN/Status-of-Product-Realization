using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphWithLabels.Models
{

    // in this class there are table models. so if you rename a column name remember to 
    // change it here too. and if there are some extera data in models feel free to erase it.
    [Keyless]
    public class StationNode
    {
        public string StationName { get; set; }
        public int NodeID { get; set; }
        public string SectionName { get; set; }
        public int? ParentID { get; set; }
    }

    [Keyless]
    public class DocInfo
    {
        public int ReqDocTypeID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int NodeID { get; set; }
        public int? AppDocTypeID { get; set; }
    }

    [Table("Station")]
    public class Station
    {
        [Key]
        public int stationId { get; set; }  // Maps to the primary key in your table
        public string stationName { get; set; }  // Maps to the stationName column
        public int layerId { get; set; }
        //public string? requiredDocId { get; set; }
    }

    public class DocTypes
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int precent { get; set; }
    }


}
