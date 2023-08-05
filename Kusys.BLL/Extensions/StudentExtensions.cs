using Kusys.Domains.Domains;
using Kusys.Domains.ViewModel;

namespace Kusys.BLL.Extensions;

public static class StudentExtensions
{
    public static Student MapToEntity(this StudentViewModel studentModel)
    {
        return new Student()
        {
            Id = studentModel.Id,
            FirstName = studentModel.FirstName,
            LastName = studentModel.LastName,
            BirthDate = studentModel.BirthDate,
            CourseId = studentModel.CourseId,
            CreatedDate = studentModel.CreatedDate
        };
    }

    public static StudentViewModel MapToViewModel(this Student student)
    {
        return new StudentViewModel()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            BirthDate = student.BirthDate,
            CourseId = student.CourseId,
            CreatedDate = student.CreatedDate
        };
    }

    public static List<StudentViewModel> MapToViewModelList(this List<Student> students)
    {
        var list = new List<StudentViewModel>();

        foreach (var student in students)
        {
            list.Add(new StudentViewModel()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                CourseId = student.CourseId,
                BirthDate = student.BirthDate,
                CreatedDate = student.CreatedDate
            });
        }

        return list;
    }
}