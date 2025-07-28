using Microsoft.EntityFrameworkCore;

namespace GraphWithLabels.Models
{
    public class DatabaseMethods
    {
        private readonly ApplicationDbContext _context;
        public DatabaseMethods(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Station> getStations()
        {
            List<Station> station = _context.station.ToList();
            return station;
        }

        public List<StationNode> getStationNodes_con(int stationId)
        {
            string sql = @"
                SELECT
                  station.stationName as StationName,
                  TreeSectionCharts.ID AS ParentID,
                  child.SectionName,
                  child.ID as NodeID
                FROM
                  dbo.station
                  INNER JOIN dbo.layer ON station.layerID = layer.intLayerTypeID
                  INNER JOIN dbo.SectionTypes ON layer.sectionTypeID = SectionTypes.ID
                  INNER JOIN dbo.SectionTypeTreeSectionCharts ON SectionTypes.ID = SectionTypeTreeSectionCharts.SectionType_ID
                  INNER JOIN dbo.TreeSectionCharts ON SectionTypeTreeSectionCharts.TreeSectionChart_ID = TreeSectionCharts.ID
                  LEFT JOIN dbo.TreeSectionCharts AS child ON TreeSectionCharts.ParentID = child.ID 
                WHERE
                    station.stationID = {0}";

            return _context.Set<StationNode>().FromSqlRaw(sql, stationId).ToList();
        }

        public List<StationNode> getStationNodes_div(int stationId)
        {
            string sql = @"
                SELECT
                  station.StationName,
                  TreeSectionCharts.ID AS NodeID,
                  TreeSectionCharts.SectionName,
                  TreeSectionCharts.ParentID 
                FROM dbo.station
                INNER JOIN dbo.layer ON station.layerID = layer.intLayerTypeID
                INNER JOIN dbo.SectionTypes ON layer.sectionTypeID = SectionTypes.ID
                INNER JOIN dbo.SectionTypeTreeSectionCharts ON SectionTypes.ID = SectionTypeTreeSectionCharts.SectionType_ID
                INNER JOIN dbo.TreeSectionCharts ON SectionTypeTreeSectionCharts.TreeSectionChart_ID = TreeSectionCharts.ID 
                WHERE station.stationID = {0}";

            return _context.Set<StationNode>().FromSqlRaw(sql, stationId).ToList();
        }

        public List<StationNode> getStationNodes_fix(int stationId)
        {
            string sql = @"
                SELECT
	                station.stationName, 
	                TreeSectionCharts.ID AS NodeID, 
	                TreeSectionCharts.SectionName, 
	                TreeSectionCharts.ID AS ParentID
                FROM
	                dbo.station
	                INNER JOIN
	                dbo.layer
	                ON 
		                station.layerID = layer.intLayerTypeID
	                INNER JOIN
                dbo.SectionTypes ON layer.sectionTypeID = SectionTypes.ID
                INNER JOIN dbo.SectionTypeTreeSectionCharts
	                ON 
		                SectionTypes.ID = SectionTypeTreeSectionCharts.SectionType_ID
	                INNER JOIN
	                dbo.TreeSectionCharts
	                ON 
		                SectionTypeTreeSectionCharts.TreeSectionChart_ID = TreeSectionCharts.ID
                WHERE
	                station.stationID = {0}";

            return _context.Set<StationNode>().FromSqlRaw(sql, stationId).ToList();
        }

        public List<DocInfo> getDocInfos_con(int stationId)
        {
            string sql = @"
                WITH reqDoc AS (
                  SELECT
                    CAST(ltrim(RTRIM(PARSENAME(REPLACE(VALUE, ',', '.'), 2))) AS INT) AS reqDocTypeID,
                    CAST(ltrim(RTRIM(PARSENAME(REPLACE(VALUE, ',', '.'), 1))) AS INT) AS weight
                  FROM
                    string_split ( ( SELECT requiredDocID FROM station WHERE stationID = {0} ), ';' ) -- here
  
                ),
                stationNode AS (
                  SELECT
                    station.stationName AS StationName,
                    TreeSectionCharts.ID AS ParentID,
                    child.SectionName,
                    child.ID AS NodeID 
                  FROM
                    dbo.station
                    INNER JOIN dbo.layer ON station.layerID = layer.intLayerTypeID
                    INNER JOIN dbo.SectionTypes ON layer.sectionTypeID = SectionTypes.ID
                    INNER JOIN dbo.SectionTypeTreeSectionCharts ON SectionTypes.ID = SectionTypeTreeSectionCharts.SectionType_ID
                    INNER JOIN dbo.TreeSectionCharts ON SectionTypeTreeSectionCharts.TreeSectionChart_ID = TreeSectionCharts.ID
                    LEFT JOIN dbo.TreeSectionCharts AS child ON TreeSectionCharts.ParentID = child.ID 
                  WHERE
                    station.stationID = {0} -- here
    
                  ),
                  requiredDoc AS ( SELECT reqDocTypeID, weight, nodeID FROM reqDoc, stationNode ),
                  approvedDoc AS (
                  SELECT DISTINCT
                    stationNode.nodeID,
                    DocTypes.ID AS appDocTypeID 
                  FROM
                    Documents
                    INNER JOIN DocTypes ON Documents.DOCTYPEID = DocTypes.ID
                    INNER JOIN TreeSectionChartDocuments ON Documents.ID = TreeSectionChartDocuments.Document_ID
                    INNER JOIN stationNode ON stationNode.NodeID = TreeSectionChartDocuments.TreeSectionChart_ID 
                  ),
                  comparedDoc AS (
                  SELECT
                    requiredDoc.reqDocTypeID,
                    requiredDoc.weight,
                    requiredDoc.nodeID,
                    approvedDoc.appDocTypeID 
                  FROM
                    approvedDoc
                    RIGHT JOIN requiredDoc ON approvedDoc.nodeID = requiredDoc.nodeID 
                    AND approvedDoc.appDocTypeID = requiredDoc.reqDocTypeID 
                  ) SELECT DISTINCT
                  comparedDoc.reqDocTypeID,
                  doctypes.Name,
                  comparedDoc.weight,
                  comparedDoc.nodeID,
                  comparedDoc.appDocTypeID 
                FROM
                  comparedDoc
                  INNER JOIN DocTypes ON comparedDoc.reqDocTypeID = doctypes.ID";

            var result = _context.Set<DocInfo>().FromSqlRaw(sql, stationId).ToList();
            return result;
        }
        public List<DocInfo> getDocInfos_div(int stationId)
        {
            string sql = @"
                WITH reqDoc AS (
                  SELECT 
                    CAST(ltrim(RTRIM(PARSENAME(REPLACE(VALUE, ',', '.'), 2))) AS INT) AS reqDocTypeID,
                    CAST(ltrim(RTRIM(PARSENAME(REPLACE(VALUE, ',', '.'), 1))) AS INT) AS weight
                  FROM
                    string_split ( ( SELECT requiredDocID FROM station WHERE stationID = {0} ), ';' )  
                ),
                stationNode AS (
                  SELECT
                    station.stationName,
                    TreeSectionCharts.ID AS nodeID,
                    TreeSectionCharts.SectionName,
                    TreeSectionCharts.ParentID 
                  FROM
                    station
                    INNER JOIN layer ON station.layerID = layer.intLayerTypeID
                    INNER JOIN SectionTypes ON layer.sectionTypeID = SectionTypes.ID
                    INNER JOIN SectionTypeTreeSectionCharts ON SectionTypes.ID = SectionTypeTreeSectionCharts.SectionType_ID
                    INNER JOIN TreeSectionCharts ON SectionTypeTreeSectionCharts.TreeSectionChart_ID = TreeSectionCharts.ID 
                  WHERE
                    station.stationID = {0} 
                  ),
                  requiredDoc AS ( SELECT reqDocTypeID, weight, nodeID FROM reqDoc, stationNode ),
                  approvedDoc AS (
                  SELECT DISTINCT
                    stationNode.nodeID,
                    DocTypes.ID AS appDocTypeID
                  FROM
                    Documents
                    INNER JOIN DocTypes ON Documents.DOCTYPEID = DocTypes.ID
                    INNER JOIN TreeSectionChartDocuments ON Documents.ID = TreeSectionChartDocuments.Document_ID
                    INNER JOIN stationNode ON stationNode.nodeID = TreeSectionChartDocuments.TreeSectionChart_ID 
                  ),
                  comparedDoc AS (
                  SELECT
                    requiredDoc.reqDocTypeID,
                    requiredDoc.weight,
                    requiredDoc.nodeID,
                    approvedDoc.appDocTypeID
                  FROM
                    approvedDoc
                    RIGHT JOIN requiredDoc ON approvedDoc.nodeID = requiredDoc.nodeID 
                    AND approvedDoc.appDocTypeID = requiredDoc.reqDocTypeID 
                  ) SELECT
                  comparedDoc.reqDocTypeID,
                  doctypes.Name, 
                  comparedDoc.weight,
                  comparedDoc.nodeID,
                  comparedDoc.appDocTypeID
                FROM
                  comparedDoc
                  INNER JOIN
                  DocTypes on comparedDoc.reqDocTypeID = doctypes.ID";

            var result = _context.Set<DocInfo>().FromSqlRaw(sql, stationId).ToList();
            return result;
        }
        public List<DocInfo> getDocInfos_fix(int stationId)
        {
            string sql = @"
                WITH reqDoc AS (
                  SELECT
                    CAST(ltrim(RTRIM(PARSENAME(REPLACE(VALUE, ',', '.'), 2))) AS INT) AS reqDocTypeID,
                    CAST(ltrim(RTRIM(PARSENAME(REPLACE(VALUE, ',', '.'), 1))) AS INT) AS weight
                  FROM
                    string_split ( ( SELECT requiredDocID FROM station WHERE stationID = {0} ), ';' )  -- here
                ),
                stationNode AS (
                  SELECT
                    station.stationName,
                    TreeSectionCharts.ID AS nodeID,
                    TreeSectionCharts.SectionName,
                    TreeSectionCharts.ID AS ParentID
                  FROM
                    station
                    INNER JOIN layer ON station.layerID = layer.intLayerTypeID
                    INNER JOIN SectionTypes ON layer.sectionTypeID = SectionTypes.ID
                    INNER JOIN SectionTypeTreeSectionCharts ON SectionTypes.ID = SectionTypeTreeSectionCharts.SectionType_ID
                    INNER JOIN TreeSectionCharts ON SectionTypeTreeSectionCharts.TreeSectionChart_ID = TreeSectionCharts.ID 
                  WHERE
                    station.stationID = {0}  -- here
                  ),
                  requiredDoc AS ( SELECT reqDocTypeID, weight, nodeID FROM reqDoc, stationNode ),
                  approvedDoc AS (
                  SELECT DISTINCT
                    stationNode.nodeID,
                    DocTypes.ID AS appDocTypeID
                  FROM
                    Documents
                    INNER JOIN DocTypes ON Documents.DOCTYPEID = DocTypes.ID
                    INNER JOIN TreeSectionChartDocuments ON Documents.ID = TreeSectionChartDocuments.Document_ID
                    INNER JOIN stationNode ON stationNode.nodeID = TreeSectionChartDocuments.TreeSectionChart_ID 
                  ),
                  comparedDoc AS (
                  SELECT
                    requiredDoc.reqDocTypeID,
                    requiredDoc.weight,
                    requiredDoc.nodeID,
                    approvedDoc.appDocTypeID
                  FROM
                    approvedDoc
                    RIGHT JOIN requiredDoc ON approvedDoc.nodeID = requiredDoc.nodeID 
                    AND approvedDoc.appDocTypeID = requiredDoc.reqDocTypeID 
                  ) SELECT
                  comparedDoc.reqDocTypeID,
                  doctypes.Name, 
                  comparedDoc.weight,
                  comparedDoc.nodeID,
                  comparedDoc.appDocTypeID
                FROM
                  comparedDoc
                  INNER JOIN
                  DocTypes on comparedDoc.reqDocTypeID = doctypes.ID";

            var result = _context.Set<DocInfo>().FromSqlRaw(sql, stationId).ToList();
            return result;
        }


    }
}
