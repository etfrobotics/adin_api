using adin_api.Data.Models;
using adin_api.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace adin_api.Data.Configuration
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<User, RegisterUserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserWithRolesDTO>().ReverseMap();

            CreateMap<Task, CreateTaskDTO>().ReverseMap();
            CreateMap<Task, TaskDTO>().ReverseMap();
            CreateMap<Task, TaskWithStepsDTO>().ReverseMap();

            CreateMap<Step, CreateStepDTO>().ReverseMap();
            CreateMap<Step, StepDTO>().ReverseMap();
            CreateMap<Step, StepDetailsDTO>().ReverseMap();
            CreateMap<Step, StepBasicWithTaskDTO>().ReverseMap();
            CreateMap<Step, StepWithIdDTO>().ReverseMap();

            CreateMap<Component, ComponentBasicDTO>().ReverseMap();
            CreateMap<Component, CreateComponentDTO>().ReverseMap();

            CreateMap<Tool, ToolBasicDTO>().ReverseMap();
            CreateMap<Tool, CreateToolDTO>().ReverseMap();

            CreateMap<SafetyTool, SafetyToolBasicDTO>().ReverseMap();
            CreateMap<SafetyTool, CreateSafetyToolDTO>().ReverseMap();

            CreateMap<Image, ImageDTO>().ReverseMap();
            CreateMap<Image, CreateImageDTO>().ReverseMap();
        }
    }
}
