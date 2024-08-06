using Microsoft.EntityFrameworkCore;
using System;
using static System.Collections.Specialized.BitVector32;

namespace GraphWithLabels.Models
{
    public class DatabaseMethods
    {
        private readonly ApplicationDbContext _context;

        public DatabaseMethods(ApplicationDbContext context)
        {
            _context = context;
        }

        public Station? getStation(int stationId)
        {
            Station? station = _context.station
                           .FirstOrDefault(s => s.stationId == stationId);
            return station;
        }

        public Layer? getLayer(int layerId)
        {
            Layer? layer = _context.layer
                                   .FirstOrDefault(s => s.intLayerTypeId == layerId);
            return layer;
        }

        public List<SectionTypeTreeSectionCharts> getSectionTypeTreeSectionCharts(int sectionType_ID)
        {
            return _context.sectionTypeTreeSectionChart
                           .Where(p => p.SectionType_ID == sectionType_ID)
                           .ToList();
        }

        public TreeSectionCharts? getTreeSectionCharts(int ID)
        {
            TreeSectionCharts? treeSectionCharts = _context.treeSectionChart
                                                    .FirstOrDefault(s => s.ID == ID);
            return treeSectionCharts;
        }

        public bool is_child(int childId, int? parentId)
        {
            if (parentId == null)
            {
                return false;
            }

            var result = _context.treeSectionChart
                .FromSqlRaw(@"
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
                .ToList()
                .Any();

            return result;
        }

        public bool is_parent(int childId, int? parentId)
        {
            if (parentId == null)
            {
                return false;
            }

            var result = _context.treeSectionChart
                .FromSqlRaw(@"
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
            .ToList()
            .Any();

            return result;
        }


        public List<int> extract_numbers(String s_numbers)
        {
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

    }
}
