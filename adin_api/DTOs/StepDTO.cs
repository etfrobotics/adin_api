using adin_api.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.DTOs
{
    public class StepBasicDTO
    {

        [Required]
        public int StepNumber { get; set; }

        [Required]
        public string Instructions { get; set; }

        public int? RackId { get; set; }

        [Required]
        public int TaskId { get; set; }

    }


    public class CreateStepDTO : StepBasicDTO
    { 
    
    }

    public class StepWithIdDTO : StepBasicDTO
    {
        [Required]
        public int Id { get; set; }
    }

    public class StepDetailsDTO : StepWithIdDTO
    {
        public IList<ComponentBasicDTO> Components { get; set; }
        public IList<ToolBasicDTO> Tools { get; set; }
        public IList<SafetyToolBasicDTO> SafetyTools { get; set; }
        public IList<ImageDTO> Images { get; set; }
    }
    public class StepBasicWithTaskDTO : StepDetailsDTO
    {
        public TaskDTO Task { get; set; }
    }

    public class StepDTO : StepWithIdDTO
    {
        public IList<StepComponent> StepComponents { get; set; }
        public IList<StepTool> StepTools { get; set; }
        public IList<StepSafetyTool> StepSafetyTools { get; set; }
        public IList<StepImage> StepImages { get; set; }

    }

}
