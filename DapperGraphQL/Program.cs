using DapperGraphQL.Data;
using DapperGraphQL.Mutation;
using DapperGraphQL.Query;
using DapperGraphQL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//MediaTR Here
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
//Data 
builder.Services.AddSingleton<ApplicationDbContext>();
//Repo
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
//GraphQL
builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()                
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddSorting();
                

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGraphQL("/graphql");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
