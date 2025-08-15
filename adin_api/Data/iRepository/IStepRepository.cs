using adin_api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.iRepository
{
    public interface IStepRepository : IGenericRepository<Step>
    {
        Task<IList<Component>> GetStepComponents(int id);
        Task<bool> AddStepComponent(int id, Component component);
        Task<bool> DeleteStepComponent(int id, Component component);

        Task<IList<Tool>> GetStepTools(int id);
        Task<bool> AddStepTool(int id, Tool tool);
        Task<bool> DeleteStepTool(int id, Tool tool);

        Task<IList<SafetyTool>> GetStepSafetyTools(int id);
        Task<bool> AddStepSafetyTool(int id, SafetyTool safetyTool);
        Task<bool> DeleteStepSafetyTool(int id, SafetyTool safetyTool);

        Task<IList<Image>> GetStepImages(int id);
        Task<bool> AddStepImage(int id, Image image);
        Task<bool> DeleteStepImage(int id, Image image);
    }
}
