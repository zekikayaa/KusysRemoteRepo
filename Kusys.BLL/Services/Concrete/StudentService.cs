using Kusys.BLL.Extensions;
using Kusys.BLL.Services.Abstract;
using Kusys.DAL.Repository.Abstract;
using Kusys.Domains.Domains;
using Kusys.Domains.ViewModel;

namespace Kusys.BLL.Services.Concrete;

public class StudentService : IStudentService
{
    private readonly IRepository<Student> _studentRepository;

    public StudentService(IRepository<Student> studentRepository)
    {
        _studentRepository = studentRepository;
    }


    public async Task<int> AddNewStudentAsync(StudentViewModel studentModel)
    {
        var student = studentModel.MapToEntity();

        var studentId = await _studentRepository.InsertAsync(student);

        return studentId;
    }

    public async Task<int> UpdateStudentAsync(StudentViewModel studentModel)
    {
        var student = studentModel.MapToEntity();

        return await _studentRepository.UpdateAsync(student);
    }

    public async Task<bool> UpdateStudentAsync(Student student)
    {
        var result = await _studentRepository.UpdateAsync(student);

        return result == 1;
    }

    public async Task<bool> DeleteStudentAsync(int studentId)
    {
        var student = await GetByIdAsync(studentId);

        if (student == null)
            return false;

        var result = await _studentRepository.Delete(student);

        return result == 1;
    }

    public async Task<Student?> GetByIdAsync(int studentId)
    {
        var student = await _studentRepository.GetByIdAsync(studentId);

        return student;
    }

    public async Task<Student?> GetByIdWithCourseAsync(int studentId)
    {
        var studentWithCourse = await _studentRepository.GetByIdWithIncludeAsync(studentId, nameof(Course));

        return studentWithCourse;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync();

        return students;
    }

    public async Task<List<Student>> GetAllWithCourseAsync()
    {
        var allStudentWithCourse = await _studentRepository.GetAllWithIncludingAsync(nameof(Course));

        return allStudentWithCourse;
    }
}