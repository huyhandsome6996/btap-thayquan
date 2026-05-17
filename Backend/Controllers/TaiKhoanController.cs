using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;

[ApiController] // Dán cái nhãn này để C# tự động lo hết phần dịch dữ liệu, mình đỡ phải viết code tay mệt mỏi
[Route("api/taikhoan")] // Đây là ngã rẽ đường dẫn chính, gõ đúng cái này là tới nơi nha
public class TaiKhoanController : ControllerBase
{
    // --- KHU VỰC XỬ LÝ ĐĂNG NHẬP ---
    [HttpPost("dang-nhap")]
    public IActionResult DangNhap([FromBody]DangNhapRequest yeucau)
    {
        // 1. Hứng mấy cái thông tin mà người ta gõ bên giao diện gửi qua
        string ten = yeucau.TenDangNhap;
        string mk = yeucau.MatKhau;

        // 2. Nhớ kiểm tra xem người ta có bỏ trống ô nào không nè
        if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(mk))
        {
            return BadRequest(new { thongBao = "Bạn ơi, vui lòng nhập đầy đủ cả tên đăng nhập và mật khẩu nhé!" });
        }

        // 3. So khớp xem có đúng tài khoản admin thần thánh không
        if (ten == "admin" && mk == "123456")
        {
            return Ok(new { thongBao = "Tuyệt vời! Đăng nhập thành công rồi nha!" });
        }

        // 4. Nếu gõ sai thì phải báo cho người ta biết để gõ lại nè
        return BadRequest(new { thongBao = "Tên đăng nhập hoặc mật khẩu không đúng rồi, bạn kiểm tra lại thử xem!" });
    }

    // --- KHU VỰC XỬ LÝ ĐĂNG KÝ ---
    [HttpPost("dang-ky")]
    public IActionResult DangKy(DangKyRequest yeuCau)
    {
        // Tạo một cái túi rỗng để lát nữa gom hết mấy lỗi phát sinh lại báo một lượt
        string thongBaoLoi = "";

        // 1. Phải chắc chắn là không có ô nhập liệu nào bị bỏ trống
        if (string.IsNullOrEmpty(yeuCau.Ho) || string.IsNullOrEmpty(yeuCau.Ten) || 
            string.IsNullOrEmpty(yeuCau.TenDangNhap) || string.IsNullOrEmpty(yeuCau.MatKhau) ||
            string.IsNullOrEmpty(yeuCau.Email) || string.IsNullOrEmpty(yeuCau.QueQuan))
        {
            thongBaoLoi = thongBaoLoi + "- Bạn nhớ điền đầy đủ tất cả các trường thông tin nhé!\n";
        }

        // 2. Kiểm tra xem người ta chọn ngày sinh chưa và đã đủ 16 tuổi chưa
        if (string.IsNullOrEmpty(yeuCau.NgaySinh))
        {
            thongBaoLoi = thongBaoLoi + "- Bạn ơi, bạn chưa chọn ngày sinh kìa!\n";
        }
        else
        {
            DateTime ngaySinh = DateTime.Parse(yeuCau.NgaySinh);
            int namHienTai = DateTime.Now.Year;
            int tuoi = namHienTai - ngaySinh.Year;
            
            // Nếu năm sinh tính ra chưa đủ 16 tuổi thì báo ngay
            if (tuoi < 16)
            {
                thongBaoLoi = thongBaoLoi + "- Bạn phải từ 16 tuổi trở lên mới được tham gia nha!\n";
            }
        }

        // 3. Email thì bắt buộc phải có ký tự @ thì mới hợp lệ nha
        if (string.IsNullOrEmpty(yeuCau.Email) == false)
        {
            if (yeuCau.Email.Contains("@") == false)
            {
                thongBaoLoi = thongBaoLoi + "- Địa chỉ Email không hợp lệ (nhớ thêm ký tự @ vào bạn nhé)!\n";
            }
        }

        // 4. Bắt buộc người ta phải click tích chọn đồng ý điều khoản thì mới cho đi tiếp
        if (yeuCau.DongY == false)
        {
            thongBaoLoi = thongBaoLoi + "- Bạn cần phải tích chọn đồng ý với điều khoản sử dụng nha!\n";
        }

        // --- ĐOẠN CUỐI: TỔNG HỢP KẾT QUẢ ---
        // Nếu trong túi có chứa bất kỳ lỗi nào, trả về lỗi ngay để người ta sửa
        if (thongBaoLoi != "")
        {
            return BadRequest(new { thongBao = thongBaoLoi });
        }

        // Nếu mọi thứ trơn tru, không có lỗi gì thì chúc mừng họ thôi!
        return Ok(new { thongBao = "Chúc mừng bạn! Tài khoản đã được đăng ký thành công rồi nhé!" });
    }
}
