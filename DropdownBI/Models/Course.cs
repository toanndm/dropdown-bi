namespace DropdownBI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? CourseId { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public int CourseType { get; set; }
        public string? Category {  get; set; }
    }
}
