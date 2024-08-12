using DapperGraphQL.ApplicationCommands.Command;
using DapperGraphQL.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace DapperGraphQL.Mutation;

public class Mutation
{
    public async Task<Student> AddStudent([FromBody] Student student, [Service] ISender sender)
    {
        var result = await sender.Send(new AddStudentCommand(student));
        return result;
    }
    public async Task<bool> UpdateStudent([FromRoute] int id, [FromBody] Student student, [Service] ISender sender)
    {
        var result = await sender.Send(new UpdateStudentCommand(id, student));
        return result;
    }
    public async Task<bool> DeleteStudent([FromRoute] int id, [Service] ISender sender)
    {
        var result = await sender.Send(new DeleteStudentCommand(id));
        return result;
    }
}
