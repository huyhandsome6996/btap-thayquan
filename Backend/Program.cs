using System.IO;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Kích hoạt tính năng Controller để viết code xử lý các chức năng đăng nhập, đăng ký
builder.Services.AddControllers(); 

var app = builder.Build();

// Cài đặt để khi vừa mở web lên là nó tự động nhảy vào trang chủ index.html luôn
app.UseDefaultFiles(new DefaultFilesOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "..", "GiaoDien")),
    RequestPath = ""
});

// Bật tính năng tải các file tĩnh (như giao diện HTML, phong cách CSS hay code JS) từ thư mục GiaoDien
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "..", "GiaoDien")),
    RequestPath = ""
});

// Liên kết các đường truyền từ trình duyệt web vào đúng các Controller xử lý ở Backend
app.MapControllers(); 

// Lệnh khởi động toàn bộ hệ thống lên và bắt đầu chạy thôi!
app.Run();
