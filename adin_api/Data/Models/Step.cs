using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Models
{
    public class Step
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("step_number")]
        public int StepNumber { get; set; }
        [Column("instructions", TypeName = "VARCHAR(1000)")]
        public string Instructions { get; set; }

        [Column("rack_id")]
        public int? RackId { get; set; }

        [Column("task_id")]
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public IList<StepComponent> StepComponents { get; set; }
        public IList<StepTool> StepTools { get; set; }
        public IList<StepSafetyTool> StepSafetyTools { get; set; }
        public IList<StepImage> StepImages { get; set; }

    }
}
