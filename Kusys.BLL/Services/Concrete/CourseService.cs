using Kusys.BLL.Services.Abstract;
using Kusys.DAL.Repository.Abstract;
using Kusys.Domains.Domains;
using Kusys.Domains.ViewModel;

namespace Kusys.BLL.Services.Concrete;

public class CourseService : ICourseService
{
    private readonly IRepository<Course> _courseRepository;

    public CourseService(IRepository<Course> courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        var courses = await _courseRepository.GetAllAsync();

        return courses;
    }

    public async Task<List<Course>> GetAllWithStudentAsync()
    {
        var coursesWithStudents = await _courseRepository.GetAllWithIncludingAsync("Students");

        return coursesWithStudents;
    }

    public List<CourseViewModel> MapToViewModel()
    {
        throw new NotImplementedException();
    }
}