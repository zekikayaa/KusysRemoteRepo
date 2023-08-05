namespace Kusys.Domains.Domains;

public class Course : BaseEntity
{
    //CourseCode would be practical instead of CourseID
    public string Code { get; set; }
    public string Name { get; set; }
    public ICollection<Student> Students { get; set; }
}