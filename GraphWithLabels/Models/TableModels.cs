using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphWithLabels.Models
{
    // in this class there are table models. so if you rename a column name remember to 
    // change it here too. and if there are some extera data in models feel free to erase it.
    [Table("Station")]
    public class Station
    {
        [Key]
        public int stationId { get; set; }  // Maps to the primary key in your table
        public string stationName { get; set; }  // Maps to the stationName column
        public int layerId { get; set; }
        public string? requiredDocId { get; set; }
    }

    [Table("Layer")]
    public class Layer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intLayerTypeId { get; set; }
        public string layerName { get; set; }
        public string sectionTypeId { get; set; }
        public int layerLevel { get; set; }
    }

    [Table("SectionTypes")]
    public class SectionTypes
    {
        public int ID { get; set; }
        public string TypeName {  get; set; }
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

    [Table("DocTypes")]
    public class DocTypes
    {
        public int ID { get; set; }
        //public int DocTypeGroupId { get; set; }
        //public int Count { get; set; }

        public string Name { get; set; }
        //public string Code { get; set; }
        //public string Comment { get; set; }
        //public string TempFile { get; set; }
        //public string Color { get; set; }
        //public bool Active { get; set; }
        //public bool IsHistory { get; set; }
        //public bool IsAllowDownloadOther { get; set; }

        [NotMapped]
        public int precent { get; set; }
    }

    [Table("Documents")]
    public class Documents
    {
        public int ID { get; set; }
        //public String DocName { get; set; }
        //public String DocCode { get; set; }
        //public String ProjectName { get; set; }
        //public String ProjectCode { get; set; }
        //public String DocAbstract { get; set; }
        //public String DokKey { get; set; }
        //public String DocPageNum { get; set; }
        //public int AccessSecurityLevelID { get; set; }
        //public String DocDate { get; set; }
        //public String AuthorName { get; set; }
        //public String OthersAuthor { get; set; }
        //public String TechSurveyorNameText { get; set; }
        //public String ApproverNameText { get; set; }
        //public String InsertType { get; set; }
        //public String DocEditFile { get; set; }
        //public String DocPdfFile { get; set; }
        //public String DocOtherFile { get; set; }
        public int DOCTYPEID { get; set; }
        //public String DocSection { get; set; }
        //public String DocScope { get; set; }
        //public String DocOld { get; set; }
        //public String DocComment { get; set; }
        //public String ApplicationNumber { get; set; }
        //public String LinkToTreePlace { get; set; }
        //public bool isValid { get; set; }
        //public String Description { get; set; }
        
    }

    [Keyless]
    [Table("TreeSectionChartDocuments")]
    public class TreeSectionChartDocuments
    {
        public int TreeSectionChart_ID { get; set; }
        public int Document_ID { get; set; }
    }

}
