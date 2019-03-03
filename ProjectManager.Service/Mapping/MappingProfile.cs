using System.Linq;
using AutoMapper;
using ProjectManager.Contract.Project;
using ProjectManager.Contract.Task;
using ProjectManager.Contract.User;
using ProjectManager.Model;

namespace ProjectManager.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectContract>()
            .ForMember(x => x.Manager, z => z.MapFrom(x => x.Users.ToList().FirstOrDefault()))
            .ForMember(x => x.Tasks, z => z.MapFrom(x => x.Tasks));         
            CreateMap<User, UserContract>();
            CreateMap<ParentTask, ParentTaskContract>();
            CreateMap<User, UserContract>().ForMember(x => x.Name, z => z.MapFrom(a => a.FirstName + " " + a.LastName));
            CreateMap<Task, TaskContract>()                
                .ForMember(x => x.Manager, z => z.MapFrom(x => x.Users.FirstOrDefault()));
            CreateMap<UserContract, User>();
            CreateMap<ProjectContract, Project>();
            CreateMap<TaskContract, Task>();
            CreateMap<ParentTaskContract, ParentTask>();
            CreateMap<TaskContract, ParentTask>();
        }        
    }
}
