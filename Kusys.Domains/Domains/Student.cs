namespace Kusys.Domains.Domains;

public class Student : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
}