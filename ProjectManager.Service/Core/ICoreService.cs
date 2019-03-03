using ProjectManager.Contract.Project;
using ProjectManager.Contract.Task;
using ProjectManager.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Service.Core
{
    public interface ICoreService
    {
        List<ProjectContract> GetProject();

        List<ProjectContract> GetProject(string criteria);

        List<ProjectContract> GetProject(int projectId);

        string AddProject(ProjectContract data);

        bool DeleteProject(int id);

        List<UserContract> GetUsers();

        List<UserContract> GetUsers(string criteria);

        string AddUser(UserContract data);

        bool DeleteUser(int id);

        List<TaskContract> GetTasks();

        List<TaskContract> GetTasks(int projectId);

        TaskContract GetTask(int id);

        string AddTask(TaskContract data);

        bool DeleteTask(int id);

        List<ParentTaskContract> GetParentTasks();
    }
}
