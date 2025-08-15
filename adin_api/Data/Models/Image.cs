using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Models
{
    [Table("StepImage")]
    public class Image
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name", TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        [Column("image", TypeName = "VARCHAR(8000)")]
        public string Link { get; set; }

        public IList<StepImage> StepImages { get; set; }

    }
}
