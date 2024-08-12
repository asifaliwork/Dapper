using DapperGraphQL.Models;
using MediatR;

namespace DapperGraphQL.ApplicationCommands.Query;

public record GetAllStudentQuery() : IRequest<IEnumerable<Student>>;
public record GetStudentByIdQuery(int id) : IRequest<IEnumerable<Student>>;
