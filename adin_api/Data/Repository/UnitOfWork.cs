using adin_api.Data.iRepository;
using adin_api.Data.Models;
using adin_api.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private IGenericRepository<Task> _tasks;
        private IGenericRepository<Component> _components;
        private IGenericRepository<Tool> _tools;
        private IGenericRepository<Image> _images;
        private IGenericRepository<SafetyTool> _safetyTools;
        private IGenericRepository<StepComponent> _stepComponents;
        private IGenericRepository<StepTool> _stepTools;
        private IGenericRepository<StepSafetyTool> _stepSafetyTools;
        private IGenericRepository<StepImage> _stepImages;

        private IStepRepository _steps;
        
        public UnitOfWork(DatabaseContext context)
        {
            _context = context; 
        }

        public IGenericRepository<Task> Tasks => _tasks ??= new GenericRepository<Task>(_context);
        public IGenericRepository<Component> Components => _components ??= new GenericRepository<Component>(_context);
        public IGenericRepository<Tool> Tools => _tools ??= new GenericRepository<Tool>(_context);
        public IGenericRepository<Image> Images => _images ??= new GenericRepository<Image>(_context);
        public IGenericRepository<SafetyTool> SafetyTools => _safetyTools ??= new GenericRepository<SafetyTool>(_context);
        public IGenericRepository<StepComponent> StepComponents => _stepComponents ??= new GenericRepository<StepComponent>(_context);
        public IGenericRepository<StepTool> StepTools => _stepTools ??= new GenericRepository<StepTool>(_context);
        public IGenericRepository<StepSafetyTool> StepSafetyTools => _stepSafetyTools ??= new GenericRepository<StepSafetyTool>(_context);
        public IGenericRepository<StepImage> StepImages => _stepImages ??= new GenericRepository<StepImage>(_context);

        public IStepRepository Steps => _steps ??= new StepRepository(_context);


        public DatabaseContext Context {
            get
            {
                return _context;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
