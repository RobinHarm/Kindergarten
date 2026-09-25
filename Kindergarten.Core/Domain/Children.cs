using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarten.Core.Domain
{
    public class Children
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public string KinderGartenName { get; set; }
        public string TeacherName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
