namespace Kindergarten.Models.Children
{
    public class ChildrenUpdateViewModel
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public int? ChildrenCount { get; set; }
        public string KinderGartenName { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
