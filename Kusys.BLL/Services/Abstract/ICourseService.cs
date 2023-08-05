using Kusys.Domains.Domains;
using Kusys.Domains.ViewModel;

namespace Kusys.BLL.Services.Abstract;

public interface ICourseService
{
    Task<List<Course>> GetAllAsync();

    Task<List<Course>> GetAllWithStudentAsync();

    List<CourseViewModel> MapToViewModel();
}