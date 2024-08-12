using Dapper;
using DapperGraphQL.Data;
using DapperGraphQL.Models;
using System.Data;

namespace DapperGraphQL.Repositories;

public class StudentRepo : IStudentRepo
{
    private readonly ApplicationDbContext _context;
    public StudentRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Student> AddStudent(Student student)
    {  
        var query = "INSERT INTO Student (Id, Name, Address, Email) VALUES (@Id, @Name, @Email, @Address)";
        var parameters = new DynamicParameters();
        parameters.Add("Id", student.Id, DbType.Int32);
        parameters.Add("Name", student.Name, DbType.String);
        parameters.Add("Email", student.Email, DbType.String);
        parameters.Add("Address", student.Address, DbType.String);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
            var createdStudent = new Student
            {
               Id = student.Id,
               Name = student.Name,
               Email = student.Email,
               Address = student.Address,                      
            };
            return createdStudent;
        }     
    }

    public async Task<bool> DeleteStudent(int id)
    {
        var query = "DELETE FROM Student WHERE Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { id });
            return true;
        }
    }

    public async Task<IEnumerable<Student>> GetAllStudent()
    {
        var query = "SELECT * FROM Student";
        using (var connetion = _context.CreateConnection())
        {
            var Students = await connetion.QueryAsync<Student>(query);
            return Students.ToList();
        }
    }

    public async Task<IEnumerable<Student>> GetStudentById(int id)
    {
        var query = "SELECT * FROM Student WHERE Id = @Id;";
        using (var connection = _context.CreateConnection())
        {
            var Students = await connection.QueryAsync<Student>(query, new {id});

            return Students.ToList();
        }
    }

    public async Task<bool>  UpdateStudent(int id, Student student)
    {
        var query = "UPDATE Student SET Name = @Name, Address = @Address, Email = @Email WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", id, DbType.Int32);
        parameters.Add("Name", student.Name, DbType.String);
        parameters.Add("Email", student.Email, DbType.String);
        parameters.Add("Address", student.Address, DbType.String);
        
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
            //var createdStudent = new Student
            //{
            //    Id = id,
            //    Name = student.Name,
            //    Email = student.Email,
            //    Address = student.Address,
            //};
            return true; 
        }
    }
}









