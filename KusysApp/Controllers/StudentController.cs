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

        TempData["errorOrSuccessfully"] = string.Empty;

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

            TempData["errorOrSuccessfully"] = string.Empty;

            return View(studentViewModel);
        }

        await _studentService.AddNewStudentAsync(studentViewModel);


        TempData["errorOrSuccessfully"] = "Student Created Successfully";

        return RedirectToAction("AllStudent");
    }


    [HttpGet]
    public async Task<IActionResult> AllStudent()
    {
        var allStudent = await _studentService.GetAllAsync();

        var courses = await _courseService.GetAllAsync();

        var studentListViewModel = new StudentListViewModel()
        {
            Students = allStudent.MapToViewModelList(),
            Student = new StudentViewModel() { Courses = courses.ConvertToSelectList(0, false) },
        };

        return View(studentListViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Update([FromQuery] int studentId)
    {
        var student = await _studentService.GetByIdWithCourseAsync(studentId);

        if (student == null)
            return RedirectToAction("AllStudent");

        var studentViewModel = student.MapToViewModel();

        var courses = await _courseService.GetAllAsync();

        studentViewModel.Courses = courses.ConvertToSelectList(student.CourseId, true);

        return View(studentViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Update(StudentViewModel studentViewModel)
    {
        if (!ModelState.IsValid)
        {
            var courses = await _courseService.GetAllAsync();

            studentViewModel.Courses = courses.ConvertToSelectList(studentViewModel.CourseId, true);

            return View(studentViewModel);
        }

        var student = studentViewModel.MapToEntity();

        var result = await _studentService.UpdateStudentAsync(student);

        if (result)
            TempData["errorOrSuccessfully"] = "Student Update Successfully";

        return RedirectToAction("AllStudent");
    }


    [HttpGet]
    public async Task<IActionResult> Delete([FromQuery] int studentId)
    {
        var student = await _studentService.GetByIdWithCourseAsync(studentId);

        if (student == null)
        {
            TempData["errorOrSuccessfully"] = "Cannot find student";

            return RedirectToAction("AllStudent");
        }


        var result = await _studentService.DeleteStudentAsync(studentId);

        if (result)
            TempData["errorOrSuccessfully"] = "Student Deleted Success Fully";

        return RedirectToAction("AllStudent");
    }
}