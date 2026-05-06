using System.IO;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Khai báo dùng Controller để viết logic
builder.Services.AddControllers(); 

var app = builder.Build();

// Cấu hình để mở file index.html tự động
app.UseDefaultFiles(new DefaultFilesOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "..", "GiaoDien")),
    RequestPath = ""
});

// Cho phép tải các file HTML/CSS/JS từ thư mục GiaoDien
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "..", "GiaoDien")),
    RequestPath = ""
});

// Kết nối yêu cầu từ Web tới các Controller
app.MapControllers(); 

// Chạy ứng dụng
app.Run();
