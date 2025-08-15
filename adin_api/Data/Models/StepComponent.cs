using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Models
{
    [Table("Step_Component")]
    public class StepComponent
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("step_id")]
        [ForeignKey("Step")]
        public int StepId { get; set; }
        public Step Step { get; set; }

        [Column("component_id")]
        [ForeignKey("Component")]
        public int ComponentId { get; set; }
        public Component Component { get; set; }
    }
}
