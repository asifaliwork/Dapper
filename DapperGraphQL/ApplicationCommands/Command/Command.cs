using DapperGraphQL.Models;
using MediatR;

namespace DapperGraphQL.ApplicationCommands.Command;

public record AddStudentCommand(Student student) : IRequest<Student>;
public record UpdateStudentCommand(int id, Student student) : IRequest<bool>;
public record DeleteStudentCommand(int id) : IRequest<bool>;

