using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;

[ApiController] // Giúp C# tự hiểu dữ liệu mà không cần viết thêm nhiều lệnh phức tạp
[Route("api/taikhoan")] // Đường dẫn ngắn gọn, dễ nhớ
public class TaiKhoanController : ControllerBase
{
    // --- CHỨC NĂNG ĐĂNG NHẬP ---
    [HttpPost("dang-nhap")]
    public IActionResult DangNhap(DangNhapRequest yeuCau)
    {
        // 1. Lấy dữ liệu người dùng gửi lên
        string ten = yeuCau.TenDangNhap;
        string mk = yeuCau.MatKhau;

        // 2. Kiểm tra nếu để trống
        if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(mk))
        {
            return BadRequest(new { thongBao = "Vui lòng nhập đủ thông tin!" });
        }

        // 3. Kiểm tra đúng tài khoản admin không
        if (ten == "admin" && mk == "123456")
        {
            return Ok(new { thongBao = "Đăng nhập thành công!" });
        }

        // 4. Nếu không đúng thì báo lỗi
        return BadRequest(new { thongBao = "Sai tên hoặc mật khẩu!" });
    }

    // --- CHỨC NĂNG ĐĂNG KÝ ---
    [HttpPost("dang-ky")]
    public IActionResult DangKy(DangKyRequest yeuCau)
    {
        // Tạo một chuỗi chữ để chứa các câu báo lỗi
        string thongBaoLoi = "";

        // 1. Kiểm tra để trống các ô chính
        if (string.IsNullOrEmpty(yeuCau.Ho) || string.IsNullOrEmpty(yeuCau.Ten) || 
            string.IsNullOrEmpty(yeuCau.TenDangNhap) || string.IsNullOrEmpty(yeuCau.Email))
        {
            thongBaoLoi = thongBaoLoi + "- Bạn phải điền đủ thông tin\n";
        }

        // 2. Kiểm tra tuổi (phải >= 16)
        if (string.IsNullOrEmpty(yeuCau.NgaySinh))
        {
            thongBaoLoi = thongBaoLoi + "- Bạn chưa chọn ngày sinh\n";
        }
        else
        {
            DateTime ngaySinh = DateTime.Parse(yeuCau.NgaySinh);
            int namHienTai = DateTime.Now.Year;
            int tuoi = namHienTai - ngaySinh.Year;
            
            if (tuoi < 16)
            {
                thongBaoLoi = thongBaoLoi + "- Bạn phải từ 16 tuổi trở lên\n";
            }
        }

        // 3. Kiểm tra Email có dấu @ không
        if (string.IsNullOrEmpty(yeuCau.Email) == false)
        {
            if (yeuCau.Email.Contains("@") == false)
            {
                thongBaoLoi = thongBaoLoi + "- Email phải có dấu @\n";
            }
        }

        // 4. Kiểm tra đã tích chọn đồng ý chưa
        if (yeuCau.DongY == false)
        {
            thongBaoLoi = thongBaoLoi + "- Bạn chưa đồng ý điều khoản\n";
        }

        // --- TỔNG KẾT ---
        // Nếu có lỗi (chuỗi thông báo không còn rỗng)
        if (thongBaoLoi != "")
        {
            return BadRequest(new { thongBao = thongBaoLoi });
        }

        // Nếu mọi thứ đều ổn
        return Ok(new { thongBao = "Đăng ký thành công!" });
    }
}
