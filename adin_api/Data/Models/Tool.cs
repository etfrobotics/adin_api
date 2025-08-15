using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Models
{
    public class Tool
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("tool_name", TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        public IList<StepTool> Tools { get; set; }

    }
}
