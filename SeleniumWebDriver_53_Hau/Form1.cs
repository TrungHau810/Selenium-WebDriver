using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumWebDriver_53_Hau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
 
        private void btnOpenBrowser_53_Hau_Click(object sender, EventArgs e)
        {
            // Bài 1: Điều hướng trình duyệt đến trang google.com khi ấn nút Open Browser
            IWebDriver driver_53_Hau = new ChromeDriver();
            driver_53_Hau.Navigate().GoToUrl("https://www.google.com/");
        }

        private void btnOpen_53_Hau_Click(object sender, EventArgs e)
        {
            // Bài 2: Nhập URL trong textbox -> nhấn button để hướng trình duyệt đến trang chỉ định trong textbox 
            IWebDriver driver_53_Hau = new ChromeDriver();
            driver_53_Hau.Url = txtURL_53_Hau.Text;
            driver_53_Hau.Navigate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Bài 3a: Không nhập URL, sẽ tự động mở trang được chỉnh định
            String defaultURL_53_Hau = "https://lms.ou.edu.vn/";
            IWebDriver driver_53_Hau = new ChromeDriver();
            driver_53_Hau.Navigate().GoToUrl(defaultURL_53_Hau);

            // Bài 3b: Tắt/Đóng trình duyệt
            driver_53_Hau.Close();
        }

        private void btnCloseCMD_53_Hau_Click(object sender, EventArgs e)
        {
            // Bài 3c. Tắt màn hình đen (CommandPromt) khi run form
            ChromeDriverService chrome_53_Hau = ChromeDriverService.CreateDefaultService();
            chrome_53_Hau.HideCommandPromptWindow = true;
            // Điều hướng đến trang facebook
            IWebDriver driver_53_Hau = new ChromeDriver(chrome_53_Hau);
            driver_53_Hau.Navigate().GoToUrl("https://facebook.com/");

            // Bài 3e. Lấy URL hiện tại và in ra console
            String link_current_53_Hau = driver_53_Hau.Url;
            Console.WriteLine(link_current_53_Hau);

            // Bìa 3f. Lấy title trên web và hiển thị textbox và console
            // Note: Khi chạy câu 3f, hãy comment câu 3d để xem kết quả
            string urlTitle_53_Hau = driver_53_Hau.Title;
            Console.WriteLine(urlTitle_53_Hau);
            txtTitle_53_Hau.Text = urlTitle_53_Hau;

            // Bài 3g. Lấy page source của web và console ra màn hình:
            string pageSource_53_Hau = driver_53_Hau.PageSource;
            Console.WriteLine(pageSource_53_Hau);


            // Bài 3d. Đóng các cửa sổ trình duyệt
            driver_53_Hau.Quit();
        }

        private void backForward_53_Hau_Click_1(object sender, EventArgs e)
        {
            ChromeDriverService chrome_53_Hau = ChromeDriverService.CreateDefaultService();
            chrome_53_Hau.HideCommandPromptWindow = true;
            // Điều hướng trang
            IWebDriver driver_53_Hau = new ChromeDriver();
            driver_53_Hau.Navigate().GoToUrl("https://google.com/");
            Thread.Sleep(1000);
            driver_53_Hau.Navigate().GoToUrl("http://ou.edu.vn/");
            Thread.Sleep(5000);
            driver_53_Hau.Navigate().Back();
            Thread.Sleep(1000);
            driver_53_Hau.Navigate().Forward();
            Thread.Sleep(1000);
            driver_53_Hau.Navigate().Refresh();
        }

        private void btnOpenSearch_53_Hau_Click(object sender, EventArgs e)
        {
            // Bài 4: Bắt thanh tìm kiếm và tự động điền từ khoá vào đó
            // Điều hướng trang đến trang google.com
            IWebDriver driver_53_Hau = new ChromeDriver();
            driver_53_Hau.Navigate().GoToUrl("https://google.com/");
            // Bắt element
            IWebElement element_53_Hau = driver_53_Hau.FindElement(By.Name("q"));
            element_53_Hau.SendKeys(txtKey_53_Hau.Text);
        }

        private void btnLoginFB_53_Hau_Click(object sender, EventArgs e)
        {
            // Bài 5: Bắt element thanh nhập email/SĐT và mật khẩu để đăng nhập FB
            // Điều hướng mở trang facebook.com
            IWebDriver driver_53_Hau = new ChromeDriver();
            driver_53_Hau.Navigate().GoToUrl("https://facebook.com/");
            // Bắt 2 thanh nhập liệu
            // Bắt ô email
            IWebElement email_53_Hau = driver_53_Hau.FindElement(By.Name("email"));
            email_53_Hau.SendKeys("2251050029hau@ou.edu.vn");
            // Bắt ô mật khẩu
            // Note: thông tin email và pass là sai!
            IWebElement pass_53_Hau = driver_53_Hau.FindElement(By.Name("pass"));
            pass_53_Hau.SendKeys("ABC123");
            Thread.Sleep(2000);
            //Bắt button đăng nhập
            IWebElement login_53_Hau = driver_53_Hau.FindElement(By.Name("login"));
            login_53_Hau.Click();
        }

        private void btnForgotPass_53_Hau_Click(object sender, EventArgs e)
        {
            // Bài 6: Bắt element LinkText quên mật khẩu
            // Điều hướng mở trang facebook.com
            IWebDriver driver_53_Hau = new ChromeDriver();
            driver_53_Hau.Navigate().GoToUrl("https://facebook.com/");
            driver_53_Hau.FindElement(By.LinkText("Forgotten password?")).Click();
        }
    }
}
