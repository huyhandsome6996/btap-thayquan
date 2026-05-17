namespace Backend.Models; // Chỗ này để gom các file chứa dữ liệu vào một góc cho dễ quản lý nè

// Cái khung này là để hứng dữ liệu gửi lên khi người dùng bấm Đăng Nhập
// Dùng "record" cho nó nhẹ người, viết code ngắn gọn mà không cần rườm rà
public record DangNhapRequest(
    string TenDangNhap, // Cái tên tài khoản mà người ta gõ vào ô đăng nhập
    string MatKhau      // Mật khẩu người ta nhập để vô hệ thống
);

// Còn cái khung này là để gom toàn bộ thông tin đăng ký gửi từ dưới web lên
public record DangKyRequest(
    string Ho,          // Họ của người dùng (ví dụ: Nguyễn, Trần...)
    string Ten,         // Tên của người dùng (ví dụ: An, Bình...)
    string TenDangNhap, // Tên tài khoản mà người ta muốn tạo mới
    string MatKhau,     // Mật khẩu người ta muốn đặt cho tài khoản
    string Email,       // Email liên hệ của người ta
    string NgaySinh,    // Ngày sinh (gửi dạng chữ "năm-tháng-ngày" cho tiện xử lý)
    string GioiTinh,    // Giới tính, chọn "Nam" hoặc "Nữ" là được
    string QueQuan,     // Quê quán (chọn ở mấy tỉnh thành có sẵn)
    bool DongY          // Tích chọn đồng ý với điều khoản (Đúng / Sai)
);
