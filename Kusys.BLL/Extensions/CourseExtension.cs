using Kusys.Domains.Domains;
using Kusys.Domains.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kusys.BLL.Extensions;

public static class CourseExtension
{
    public static List<CourseViewModel> MapToViewModelList(this List<Course> courses)
    {
        return courses.Select(course => new CourseViewModel()
            {
                Id = course.Id, Code = course.Code, Name = course.Name, Students = course.Students.MapToViewModelList(),
            })
            .ToList();
    }

    public static CourseViewModel MapToViewModel(this Course course)
    {
        return new CourseViewModel()
        {
            Id = course.Id,
            Code = course.Code,
            Name = course.Name,
            Students = course.Students.MapToViewModelList()
        };
    }

    public static List<SelectListItem> ConvertToSelectList(this List<Course> courses, int selectedOptionId = 0, bool markAsSelected = false)
    {
        var listItems = new List<SelectListItem>();

        foreach (var course in courses)
        {
            var item = new SelectListItem()
            {
                Value = course.Id.ToString(),
                Text = $"{course.Code} - {course.Name}"
            };

            if (markAsSelected && course.Id == selectedOptionId)
                item.Selected = true;

            listItems.Add(item);
        }

        return listItems;
    }
}