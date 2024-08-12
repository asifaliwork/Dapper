using DapperGraphQL.ApplicationCommands.Query;
using DapperGraphQL.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace DapperGraphQL.Query;

public class Query
{
    [UsePaging(IncludeTotalCount = true, DefaultPageSize = 5)]
    [UseFiltering]
    [UseSorting]
    public Task<IEnumerable<Student>> GetAllStudents([Service] ISender sender)
    {
        return sender.Send(new GetAllStudentQuery());
    }

    [UsePaging(IncludeTotalCount = true ,DefaultPageSize =5)]
    [UseFiltering]
    [UseSorting]
    public Task<IEnumerable<Student>> GetItemById([FromRoute] int id, [Service] ISender sender)
    {
        return sender.Send(new GetStudentByIdQuery(id));
    }
    //WithOut MediaTR 
    //private readonly IStudentRepo _context;
    //public Query(IStudentRepo context)
    //{
    //    _context = context;
    //}
    //public Task<IEnumerable<Student>> GetAllStudents()
    //{
    //    return _context.GetAllStudent();
    //   // return sender.Send(new GetAllStudentQuery());
    //}

}
