using AutoMapper;
using ProjectManager.Contract.Project;
using ProjectManager.Contract.Task;
using ProjectManager.Contract.User;
using ProjectManager.Model;
using ProjectManager.Repository.Core;
using ProjectManager.Service.Core;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Service.Persistance
{
    public class CoreService : ICoreService
    {
        private readonly IUnitOfWork _unitWork;

        public CoreService(IUnitOfWork UnitWork)
        {
            _unitWork = UnitWork;
        }

        public List<ProjectContract> GetProject()
        {
            var repo = _unitWork.Repository<Project>();
            var data = repo.GetAllData();
            return Mapper.Map<List<ProjectContract>>(data);
        }

        public List<ProjectContract> GetProject(string criteria)
        {
            var repo = _unitWork.Repository<Project>();
            var data = repo.GetBasedOnCriteria(x => x.Name.Contains(criteria));
            return Mapper.Map<List<ProjectContract>>(data);
        }

        public List<ProjectContract> GetProject(int projectId)
        {
            var repo = _unitWork.Repository<Project>();
            var data = repo.GetBasedOnCriteria(x => x.Id == projectId);
            return Mapper.Map<List<ProjectContract>>(data);
        }

        public string AddProject(ProjectContract data)
        {
            var repo = _unitWork.Repository<Project>();
            var project = Mapper.Map<Project>(data);
            try
            {
                if (data.Id == 0)
                {
                    repo.Insert(project);
                }
                else
                {
                    repo.Update(project);
                }

                if (data.Manager.Id != 0)
                {
                    var userRepo = _unitWork.Repository<User>();
                    var user = userRepo.GetById(data.Manager.Id);
                    if (user != null)
                    {
                        user.ProjectId = project.Id;
                    }
                    userRepo.Update(user);
                }

                _unitWork.Save();

                return "Success";
            }
            catch (System.Exception)
            {

                throw;
            }            
        }

        public bool DeleteProject(int id)
        {
            try
            {
                var repo = _unitWork.Repository<Project>();

                var project = repo.GetById(id);

                var taskRepo = _unitWork.Repository<Task>();
                var tasks = taskRepo.GetBasedOnCriteria(x => x.ProjectId == id);

                project.Tasks.ToList().ForEach(x =>
                {
                    x.ProjectId = null;
                    //taskRepo.Update(x);
                });

                project.Users.ToList().ForEach(x =>
                {
                    x.ProjectId = null;
                });

                repo.Update(project);
                repo.Delete(id);
                _unitWork.Save();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<TaskContract> GetTasks()
        {
            var repo = _unitWork.Repository<Task>();
            var data = repo.GetAllData();
            return Mapper.Map<List<TaskContract>>(data);
        }

        public List<TaskContract> GetTasks(int projectId)
        {
            var repo = _unitWork.Repository<Task>();
            var data = repo.GetBasedOnCriteria(x => x.ProjectId == projectId);
            return Mapper.Map<List<TaskContract>>(data);
        }

        public List<ParentTaskContract> GetParentTasks()
        {
            var repo = _unitWork.Repository<ParentTask>();
            var data = repo.GetAllData();
            return Mapper.Map<List<ParentTaskContract>>(data);
        }

        public string AddTask(TaskContract data)
        {
            var repo = _unitWork.Repository<Task>();
            var project = Mapper.Map<Task>(data);
            try
            {
                if (data.IsParentTask)
                {
                    var parentRepo = _unitWork.Repository<ParentTask>();
                    var ParentTask = Mapper.Map<ParentTask>(data);
                    if(data.ParentId == 0)
                    {
                        parentRepo.Insert(ParentTask);
                    }
                    else
                    {
                        parentRepo.Update(ParentTask);
                    }
                }
                else
                {
                    if (data.Id == 0)
                    {
                        repo.Insert(project);
                    }
                    else
                    {
                        repo.Update(project);
                    }

                    if (data.Manager.Id != 0)
                    {
                        var userRepo = _unitWork.Repository<User>();
                        var user = userRepo.GetById(data.Manager.Id);
                        if (user != null)
                        {
                            user.TaskId = project.Id;
                        }
                        userRepo.Update(user);
                    }
                }

                _unitWork.Save();

                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public TaskContract GetTask(int id)
        {
            var repo = _unitWork.Repository<Task>();
            var data = repo.GetById(id);
            return Mapper.Map<TaskContract>(data);
        }

        public bool DeleteTask(int id)
        {
            try
            {
                var repo = _unitWork.Repository<Task>();
                var Task = repo.GetById(id);

                var taskRepo = _unitWork.Repository<Task>();
                var tasks = taskRepo.GetBasedOnCriteria(x => x.ProjectId == id);

                Task.Users.ToList().ForEach(x =>
                {
                    x.TaskId = null;
                    //taskRepo.Update(x);
                });
                

                repo.Update(Task);
                repo.Delete(id);
                _unitWork.Save();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<UserContract> GetUsers()
        {
            var repo = _unitWork.Repository<User>();
            var data = repo.GetAllData();
            return Mapper.Map<List<UserContract>>(data);
        }

        public List<UserContract> GetUsers(string criteria)
        {
            var repo = _unitWork.Repository<User>();
            var data = repo.GetBasedOnCriteria(x => x.FirstName.Contains(criteria) || x.LastName.Contains(criteria));
            return Mapper.Map<List<UserContract>>(data);
        }

        public string AddUser(UserContract data)
        {
            var repo = _unitWork.Repository<User>();
            var userModel = Mapper.Map<User>(data);
            
            try
            {
                if (userModel.Id == 0)
                {
                    repo.Insert(userModel);
                }
                else
                {
                    repo.Update(userModel);
                }

                _unitWork.Save();
                return "Success";
            }
            catch (System.Exception)
            {
                throw;
            }           
        }

        public bool DeleteUser(int id)
        {
            var repo = _unitWork.Repository<User>();
            try
            {
                repo.Delete(id);
                _unitWork.Save();
                return true;
            }
            catch
            {
                throw;
            }            
        }
    }
}
