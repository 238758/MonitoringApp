using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM4017Library.DataModels
{
    public class Space
    {
        public String? Id { get; set; }
        /// <summary>
        /// null if no Parent
        /// </summary>
        public String? ParentId { get; set; }
        public String? Name { get; set; }
        public String? MetaData { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Space>? Children { get; set; }
        public List<Point>? Points { get; set; }

        // derived from metadata
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? ImageUrl { get; set; }
    }
}
