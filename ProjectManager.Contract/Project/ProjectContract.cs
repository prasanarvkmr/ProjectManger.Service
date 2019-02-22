using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Contract.Project
{
    public class ProjectContract
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Priority { get; set; }
    }
}
