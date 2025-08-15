using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.DTOs
{
    public class CreateToolDTO
    {
        public string Name { get; set; }
    }

    public class ToolBasicDTO : CreateToolDTO
    {
        public int Id { get; set; }
    }

}
