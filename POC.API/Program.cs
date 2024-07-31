using Microsoft.EntityFrameworkCore;
using POC.API.GraphQLSchema;
using POC.API.GraphQLSchema.Inputs;
using POC.API.GraphQLSchema.Types;
using POC.API.Utility;
using POC.Application.Service;
using POC.Domain.Interface;
using POC.Infrastructure.DBContext;
using POC.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7183")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
// Configure services
builder.Services.AddDbContext<POCDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<AuthorService>();

builder.Services.AddGraphQLServer()
        .AddQueryType<QueryType>()
        .AddMutationType<MutationType>()
        .AddType<BookInputType>()
        .AddType<AuthorInputType>()
        .AddType<BookType>()  
        .AddType<AuthorType>();


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGraphQL();
});

app.Run();