using ProjectManager.Contract.Project;
using ProjectManager.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Contract.Task
{
    public class TaskContract
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string ParentTaskName { get; set; }

        public int? ProjectId { get; set; }                

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int Priority { get; set; }

        public string Status { get; set; }

        public bool IsParentTask { get; set; }

        //public ProjectContract Project { get; set; }

        public UserContract Manager { get; set; }

        public string ProjectName { get; set; }
    }
}
