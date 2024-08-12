using DapperGraphQL.ApplicationCommands.Command;
using DapperGraphQL.Models;
using DapperGraphQL.Repositories;
using MediatR;

namespace DapperGraphQL.ApplicationCommands.Handler;

public class AddStudentCommandHandler(IStudentRepo StudentRepo) : IRequestHandler<AddStudentCommand, Student>
{
    public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        return await StudentRepo.AddStudent(request.student);
    }
}

public class UpdateStudentCommandHandler(IStudentRepo StudentRepo) : IRequestHandler<UpdateStudentCommand, bool>
{
    public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        return await StudentRepo.UpdateStudent(request.id, request.student);
    }
}
public class DeleteStudentCommandHandler(IStudentRepo StudentRepo) : IRequestHandler<DeleteStudentCommand, bool>
{
    public Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        return StudentRepo.DeleteStudent(request.id);
    }
}
