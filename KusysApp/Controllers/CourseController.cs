using Kusys.BLL.Extensions;
using Kusys.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KusysApp.Controllers;

public class CourseController : Controller
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> AllCourses()
    {
        var courses = await _courseService.GetAllWithStudentAsync();

        var allCoursesViewModel = courses.MapToViewModelList();

        return View(allCoursesViewModel);
    }
}