using Kusys.BLL.Extensions;
using Kusys.BLL.Services.Abstract;
using Kusys.Domains.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace KusysApp.Controllers;

public class StudentController : Controller
{
    private readonly IStudentService _studentService;
    private readonly ICourseService _courseService;

    public StudentController(IStudentService studentService, ICourseService courseService)
    {
        _studentService = studentService;
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> CreateStudent()
    {
        var allCourses = await _courseService.GetAllAsync();

        TempData["SuccessfullyCreated"] = string.Empty;

        var selectList = allCourses.ConvertToSelectList();

        var newStudent = new StudentViewModel()
        {
            Courses = selectList
        };

        return View(newStudent);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(StudentViewModel studentViewModel)
    {
        if (!ModelState.IsValid)
        {
            var courses = await _courseService.GetAllAsync();

            studentViewModel.Courses = courses.ConvertToSelectList(studentViewModel.CourseId, true);

            TempData["SuccessfullyCreated"] = string.Empty;

            return View(studentViewModel);
        }

        await _studentService.AddNewStudentAsync(studentViewModel);


        TempData["SuccessfullyCreated"] = "Student Created Successfully";

        return RedirectToAction("AllStudent");
    }


    [HttpGet]
    public IActionResult AllStudent()
    {
        return View();
    }
}