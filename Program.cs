using Microsoft.EntityFrameworkCore;
using StudyHub_API.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=studyhub.db");
});

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
