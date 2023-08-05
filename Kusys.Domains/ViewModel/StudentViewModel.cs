using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kusys.Domains.ViewModel;

public class StudentViewModel
{
    public StudentViewModel()
    {
        Courses = new List<SelectListItem>();
    }

    public int Id { get; set; }

    [Required(ErrorMessage = "Name cannot be empty")]
    [Display(Name = "First Name:")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name cannot be empty")]
    [Display(Name = "Last Name:")]
    public string LastName { get; set; }

    [Display(Name = "BirthDate:")]
    public DateTime BirthDate { get; set; }

    public CourseViewModel? Course { get; set; }


    [Required(ErrorMessage = "Please select the course for student")]
    [Range(1, double.MaxValue, ErrorMessage = "Please select the course for student")]
    [Display(Name = "Course:")]
    public int CourseId { get; set; }

    // public List<CourseViewModel>? Courses { get; set; }

    public List<SelectListItem> Courses { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}