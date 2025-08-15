using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Models
{
    public class Task
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("task_description", TypeName = "VARCHAR(1000)")]
        public string TaskDescription { get; set; }

        public IList<Step> Steps { get; set; }
    }
}
