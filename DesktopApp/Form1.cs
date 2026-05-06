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
        
        // Cấu hình WebView2
        await webView.EnsureCoreWebView2Async(null);
        
        // Điều hướng tới API Backend (index.html được phục vụ ở đây)
        webView.Source = new Uri("http://localhost:5103");
        
        this.Text = "Ứng dụng Đồ án của tôi";
        this.Width = 800;
        this.Height = 600;
    }
}
