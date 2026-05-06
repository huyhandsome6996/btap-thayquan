namespace Backend.Models; // Đây là "họ tên" của thư mục chứa file này

// Đây là bản thiết kế (Model) cho yêu cầu Đăng Nhập
// "record" là một kiểu Class đặc biệt trong C# dùng để chứa dữ liệu một cách gọn nhẹ
public record DangNhapRequest(
    string TenDangNhap, // Một chuỗi chữ chứa tên người dùng nhập vào
    string MatKhau      // Một chuỗi chữ chứa mật khẩu người dùng nhập vào
);

// Đây là bản thiết kế (Model) cho yêu cầu Đăng Ký
public record DangKyRequest(
    string Ho,          // Chứa Họ
    string Ten,         // Chứa Tên
    string TenDangNhap, // Chứa Tên tài khoản muốn tạo
    string MatKhau,     // Chứa Mật khẩu muốn tạo
    string Email,       // Chứa địa chỉ Email
    string NgaySinh,    // Chứa ngày sinh (dưới dạng chữ "năm-tháng-ngày")
    string GioiTinh,    // Chứa giới tính ("Nam" hoặc "Nữ")
    string QueQuan,     // Chứa tên tỉnh thành
    bool DongY          // Kiểu Đúng/Sai (True/False) cho ô tích chọn đồng ý
);
