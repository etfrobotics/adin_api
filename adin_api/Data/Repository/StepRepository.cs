using adin_api.Data.iRepository;
using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Repository
{
    public class StepRepository : GenericRepository<Step>, IStepRepository
    {
        public StepRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<IList<Component>> GetStepComponents(int id)
        {
            var res = from a in _context.Components
                      join b in _context.StepComponents on a.Id equals b.ComponentId
                      where b.StepId == id
                      select a;
            return await res.ToListAsync();
        }

        public async Task<bool> AddStepComponent(int id,Component component)
        {
            StepComponent stepComponent = new StepComponent
            { 
                StepId = id,
                ComponentId= component.Id
            };
            var componentExist = _context.Components.Where(q => q.Id == component.Id);
            if (!componentExist.Any()) return false;
            var exist = _context.StepComponents.Where(q => q.ComponentId == component.Id && q.StepId == id).Count()>0;
            if (exist == true) return false;
            await _context.StepComponents.AddAsync(stepComponent);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteStepComponent(int id, Component component)
        {
            var componentExist = _context.Components.Where(q => q.Id == component.Id);
            if (!componentExist.Any()) return false;
            var stepComponent = _context.StepComponents.Where(q => q.ComponentId == component.Id && q.StepId == id);
            if (!stepComponent.Any()) return false;
            _context.StepComponents.Remove(stepComponent.FirstOrDefault());
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Tool>> GetStepTools(int id)
        {
            var res = from a in _context.Tools
                      join b in _context.StepTools on a.Id equals b.ToolId
                      where b.StepId == id
                      select a;
            return await res.ToListAsync();
        }
        public async Task<bool> AddStepTool(int id, Tool tool)
        {
            StepTool stepTool = new StepTool
            {
                StepId = id,
                ToolId = tool.Id
            };
            var toolExist = _context.Tools.Where(q => q.Id == tool.Id);
            if (!toolExist.Any()) return false;
            var stepToolExist = _context.StepTools.Where(q => q.ToolId == tool.Id && q.StepId == id);
            if (stepToolExist.Any()) return false;
            await _context.StepTools.AddAsync(stepTool);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteStepTool(int id, Tool tool)
        {
            var toolExist = _context.Tools.Where(q => q.Id == tool.Id);
            if (!toolExist.Any()) return false;
            var stepToolExist = _context.StepTools.Where(q => q.ToolId == tool.Id && q.StepId == id);
            if (!stepToolExist.Any()) return false;
            _context.StepTools.Remove(stepToolExist.FirstOrDefault());
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<SafetyTool>> GetStepSafetyTools(int id)
        {
            var res = from a in _context.SafetyTools
                      join b in _context.StepSafetyTools on a.Id equals b.SafetyToolId
                      where b.StepId == id
                      select a;
            return await res.ToListAsync();
        }

        public async Task<bool> AddStepSafetyTool(int id, SafetyTool safetyTool)
        {
            StepSafetyTool stepSafetyTool = new StepSafetyTool
            {
                StepId = id,
                SafetyToolId = safetyTool.Id
            };
            var safetyToolExist = _context.SafetyTools.Where(q => q.Id == safetyTool.Id);
            if (!safetyToolExist.Any()) return false;
            var stepSafetyToolExist = _context.StepSafetyTools.Where(q => q.SafetyToolId == safetyTool.Id && q.StepId == id);
            if (stepSafetyToolExist.Any()) return false;
            await _context.StepSafetyTools.AddAsync(stepSafetyTool);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteStepSafetyTool(int id, SafetyTool safetyTool)
        {
            var safetyToolExist = _context.SafetyTools.Where(q => q.Id == safetyTool.Id);
            if (!safetyToolExist.Any()) return false;
            var stepSafetyToolExist = _context.StepSafetyTools.Where(q => q.SafetyToolId == safetyTool.Id && q.StepId == id);
            if (!stepSafetyToolExist.Any()) return false;
            _context.StepSafetyTools.Remove(stepSafetyToolExist.FirstOrDefault());
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Image>> GetStepImages(int id)
        {
            var res = from a in _context.Images
                      join b in _context.StepImages on a.Id equals b.ImageId
                      where b.StepId == id
                      select a;
            return await res.ToListAsync();
        }

        public async Task<bool> AddStepImage(int id, Image image)
        {
            StepImage stepImage = new StepImage
            {
                StepId = id,
                ImageId = image.Id
            };
            var imageExist = _context.Images.Where(q => q.Id == image.Id);
            if (!imageExist.Any()) return false;
            var stepImageExist = _context.StepImages.Where(q => q.ImageId == image.Id && q.StepId == id);
            if (stepImageExist.Any()) return false;
            await _context.StepImages.AddAsync(stepImage);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteStepImage(int id, Image image)
        {
            var imageExist = _context.Images.Where(q => q.Id == image.Id);
            if (!imageExist.Any()) return false;
            var stepImageExist = _context.StepImages.Where(q => q.ImageId == image.Id && q.StepId == id);
            if (!stepImageExist.Any()) return false;
            _context.StepImages.Remove(stepImageExist.FirstOrDefault());
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
