using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Models
{
    [Table("Step_Tools")]
    public class StepTool
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("step_id")]
        [ForeignKey("Step")]
        public int StepId { get; set; }
        public Step Step { get; set; }

        [Column("tool_id")]
        [ForeignKey("Tool")]
        public int ToolId { get; set; }
        public Tool Tool { get; set; }
    }
}
