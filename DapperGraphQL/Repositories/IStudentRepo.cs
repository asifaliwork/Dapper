using DapperGraphQL.Models;

namespace DapperGraphQL.Repositories;

public interface IStudentRepo
{
    Task<IEnumerable<Student>> GetAllStudent();
    Task<IEnumerable<Student>> GetStudentById(int id);
    Task<Student> AddStudent(Student student);
    Task<bool> UpdateStudent(int id, Student student);
    Task<bool> DeleteStudent(int id);

}