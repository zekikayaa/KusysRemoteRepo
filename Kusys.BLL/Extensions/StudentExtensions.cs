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
}