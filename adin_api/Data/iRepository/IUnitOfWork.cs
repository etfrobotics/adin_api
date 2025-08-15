using adin_api.Data;
using adin_api.Data.iRepository;
using adin_api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.iRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Task> Tasks { get; }
        IGenericRepository<Component> Components { get; }
        IGenericRepository<Tool> Tools { get; }
        IGenericRepository<Image> Images { get; }
        IGenericRepository<SafetyTool> SafetyTools { get; }
        IGenericRepository<StepComponent> StepComponents { get; }
        IGenericRepository<StepTool> StepTools { get; }
        IGenericRepository<StepSafetyTool> StepSafetyTools { get; }
        IGenericRepository<StepImage> StepImages { get; }

        IStepRepository Steps { get; }

        DatabaseContext Context { get; }
    }
}
