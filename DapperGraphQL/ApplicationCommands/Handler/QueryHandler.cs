using DapperGraphQL.ApplicationCommands.Query;
using DapperGraphQL.Models;
using DapperGraphQL.Repositories;
using MediatR;

namespace DapperGraphQL.ApplicationCommands.Handler;


public class GetAllStudentQueryHandler(IStudentRepo StudentRepo) : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
{
   public Task<IEnumerable<Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
   {
      return StudentRepo.GetAllStudent();
   }
}

public class GetStudentByIdQueryHandler(IStudentRepo StudentRepo) : IRequestHandler<GetStudentByIdQuery, IEnumerable<Student>>
{
    public Task<IEnumerable<Student>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        return StudentRepo.GetStudentById(request.id);
    }   
}
