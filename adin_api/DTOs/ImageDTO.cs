using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.DTOs
{
    public class CreateImageDTO
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public class ImageDTO : CreateImageDTO
    {
        public int Id { get; set; }
    }

}
