using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImproveIT.AngularJSCourse.Domain
{
    /// <summary>
    /// Task class
    /// </summary>
    public class Task
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public User User { get; set; }

        public Task()
        {
            this.User = new User();
        }
    }
}
