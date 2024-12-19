using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace realization_graph_4._5.Models
{
    public class DatabaseMethods
    {
        private readonly ApplicationDbContext _context;

        public DatabaseMethods(ApplicationDbContext context)
        {
            _context = context;
        }

        public Station getStation(int stationId)
        {
            Station station = _context.station.AsNoTracking()
                           .FirstOrDefault(s => s.stationId == stationId);
            return station;
        }

        public Layer getLayer(int layerId)
        {
            Layer layer = _context.layer.AsNoTracking()
                                   .FirstOrDefault(s => s.intLayerTypeId == layerId);
            return layer;
        }

        public List<SectionTypeTreeSectionCharts> getSectionTypeTreeSectionCharts(int sectionType_ID)
        {
            return _context.sectionTypeTreeSectionChart.AsNoTracking()
                           .Where(p => p.SectionType_ID == sectionType_ID)
                           .ToList();
        }

        public TreeSectionCharts getTreeSectionCharts(int ID)
        {
            TreeSectionCharts treeSectionCharts = _context.treeSectionChart.AsNoTracking()
                                                    .FirstOrDefault(s => s.ID == ID);
            if (treeSectionCharts == null)
            {
                // Handle the case when no chart is found
                return null; // Or handle differently
            }
            return treeSectionCharts;
        }

        public bool is_child(int childId, int? parentId)// check if a node is a child of another node or not
        {
            if (parentId == null)
            {
                return false;
            }

            var result = _context.treeSectionChart
                .SqlQuery(@"
            WITH Ancestors AS (
                SELECT ID, SectionName, ParentID
                FROM TreeSectionCharts
                WHERE ID = {0}
                UNION ALL
                SELECT t.ID, t.SectionName, t.ParentID
                FROM TreeSectionCharts t
                INNER JOIN Ancestors a ON t.ID = a.ParentID
            )
            SELECT ID, SectionName, ParentID FROM Ancestors WHERE ID = {1}", childId, parentId.Value)
                .AsNoTracking().ToList()
                .Any();

            return result;
        }

        public bool is_parent(int childId, int? parentId)// check if a node is a parent of another node or not
        {
            if (parentId == null)
            {
                return false;
            }

            var result = _context.treeSectionChart
                .SqlQuery(@"
            WITH Descendants AS (
                SELECT ID, SectionName, ParentID
                FROM TreeSectionCharts
                WHERE ID = {0}
                UNION ALL
                SELECT t.ID, t.SectionName, t.ParentID
                FROM TreeSectionCharts t
                INNER JOIN Descendants d ON t.ID = d.ParentID
            )
            SELECT ID, SectionName, ParentID FROM Descendants WHERE ID = {1}", childId, parentId)
            .AsNoTracking().ToList()
            .Any();

            return result;
        }

        public List<TreeSectionChartDocuments> getTreeSectionChartDocuments(int treeSectionChart_ID)
        {
            return _context.treeSectionChartDocuments.AsNoTracking()
                           .Where(p => p.TreeSectionChart_ID == treeSectionChart_ID)
                           .ToList();
        }

        public Documents getDocument(int ID)
        {
            Documents documents = _context.documents.AsNoTracking()
                                           .FirstOrDefault(s => s.ID == ID);
            return documents;
        }

        public DocTypes getDocTypes(int ID)
        {
            DocTypes docTypes = _context.docTypes.AsNoTracking()
                                          .AsNoTracking()
                                          .FirstOrDefault(s => s.ID == ID);
            return docTypes;
        }

        public List<int> extract_numbers(string s_numbers)
        {// extract numbers from a string. between numbers there are cama(,)
            string[] numberStrings = s_numbers.Split(',');
            List<int> numbers = new List<int>();
            foreach (string numberString in numberStrings)
            {
                if (int.TryParse(numberString, out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"'{numberString}' is not a valid number.");
                }
            }

            return numbers;
        }

        public Dictionary<int, int> required_doc(String s_doc)
        {// extract a dictionary from a string. the format is like this -> n1,n2;n3,n4  
            Dictionary<int, int> ans = new Dictionary<int, int>();

            string[] partStrings = s_doc.Split(';');
            foreach (string s in partStrings)
            {
                string[] n = s.Split(',');
                if (int.TryParse(n[0], out int number1) && int.TryParse(n[1], out int number2))
                {
                    ans.Add(number1, number2);
                }
                else
                {
                    Console.WriteLine($"'{n[0]}' || '{n[1]}' is not a valid number.");
                }
            }
            return ans;
        }

        public Dictionary<int, bool> create_dic(Dictionary<int, int> dic)
        {// create dictionary with same keys as 'dic' and a default value 'false'
            Dictionary<int, bool> ans = new Dictionary<int, bool>();
            foreach (var key in dic.Keys)
                ans[key] = false;
            return ans;
        }
    }
}
