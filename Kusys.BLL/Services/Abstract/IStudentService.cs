using Kusys.Domains.Domains;
using Kusys.Domains.ViewModel;

namespace Kusys.BLL.Services.Abstract;

public interface IStudentService
{
    public Task<int> AddNewStudentAsync(StudentViewModel studentModel);

    public Task<int> UpdateStudentAsync(StudentViewModel studentModel);

    public Task<bool> UpdateStudentAsync(Student student);

    public Task<bool> DeleteStudentAsync(int studentId);

    public Task<Student?> GetByIdAsync(int studentId);

    public Task<Student?> GetByIdWithCourseAsync(int studentId);

    public Task<List<Student>> GetAllAsync();

    public Task<List<Student>> GetAllWithCourseAsync();
}