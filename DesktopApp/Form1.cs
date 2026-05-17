namespace DesktopApp;

using Microsoft.Web.WebView2.WinForms;

public partial class Form1 : Form
{
    private WebView2? webView;

    public Form1()
    {
        InitializeComponent();
        InitializeWebView();
    }

    private async void InitializeWebView()
    {
        webView = new WebView2
        {
            Dock = DockStyle.Fill
        };
        this.Controls.Add(webView);
        
        // Khởi động trình duyệt thu nhỏ WebView2 để hiển thị trang web bên trong ứng dụng
        await webView.EnsureCoreWebView2Async(null);
        
        // Dẫn lối cho trình duyệt chạy thẳng tới trang chủ index.html được lưu ở Backend
        webView.Source = new Uri("http://localhost:5103");
        
        this.Text = "Ứng dụng Đồ án của tôi";
        this.Width = 800;
        this.Height = 600;
    }
}
