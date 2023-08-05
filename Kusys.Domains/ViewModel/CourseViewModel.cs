using Kusys.Domains.Domains;

namespace Kusys.Domains.ViewModel;

public class CourseViewModel
{
    public int Id { get; set; }
    public string Code { get; set; }

    public string Name { get; set; }

    public ICollection<Student> Students { get; set; }

    public override string ToString()
    {
        return $"{Code} - {Name}";
    }
}