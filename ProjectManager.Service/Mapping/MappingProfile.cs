using AutoMapper;
using ProjectManager.Contract.Project;
using ProjectManager.Model;

namespace ProjectManager.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectContract>();
        }        
    }
}
