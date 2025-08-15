using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.DTOs
{
    public class CreateTaskDTO
    {
        public string TaskDescription { get; set; }
    }

    public class TaskDTO : CreateTaskDTO
    {
        public int Id { get; set; }
        
    }

    public class TaskWithStepsDTO : TaskDTO
    {
        public IList<StepDetailsDTO> Steps { get; set; }

    }
}
