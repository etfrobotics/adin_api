using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Models
{
    [Table("Step_Safety_Tools")]
    public class StepSafetyTool
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("step_id")]
        [ForeignKey("Step")]
        public int StepId { get; set; }
        public Step Step { get; set; }

        [Column("safety_tool_id")]
        [ForeignKey("SafetyTool")]
        public int SafetyToolId { get; set; }
        public SafetyTool SafetyTool { get; set; }
    }
}
