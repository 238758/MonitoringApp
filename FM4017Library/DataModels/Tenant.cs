using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM4017Library.DataModels
{
    public class Tenant
    {
        public List<Space>? Spaces { get; set; }
        public string? Name { get; set; }
        public string? Id { get; set; }
    }
}
