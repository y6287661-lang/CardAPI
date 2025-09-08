using Microsoft.EntityFrameworkCore;
using CardAPI.Data;


var builder = WebApplication.CreateBuilder(args);

// ربط قاعدة البيانات باستخدام Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// إضافة خدمات الـ API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// تفعيل Swagger لتوثيق الـ API
app.UseSwagger();
app.UseSwaggerUI();

// إعدادات HTTP
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

