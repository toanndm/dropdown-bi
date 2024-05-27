namespace DropdownBI.Models
{
    public class Enroll
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int PreviousDropdownNum { get; set; }
        public string CourseId { get; set; }
        public int PreviousDropdownUserNum { get; set; }
        public int PreviousEnrollNum { get; set; }
        public int Duration { get; set; }
        public int SessionNum { get; set; }
        public int VideoNum { get; set; }
        public int CoursewareNum { get; set; }
        public int Truth {  get; set; }
    }
}
