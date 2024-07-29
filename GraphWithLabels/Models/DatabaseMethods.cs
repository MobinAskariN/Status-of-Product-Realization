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
    }
}
