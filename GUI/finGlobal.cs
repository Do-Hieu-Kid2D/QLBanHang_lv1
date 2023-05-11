using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    [ComVisible(true)]

    public partial class finGlobal : Form
    {
        string html, tieude; //html và tieude nhận từ bố truyền sang

        public object Winsowstate { get; private set; }

        public finGlobal()
        {
            InitializeComponent();
            //khai báo hàm mở rộng cho js của webBrowser1
            webBrowser1.ObjectForScripting = this;
        }

        public void ShowPrint(string tieude, string html)
        {
            this.tieude = tieude;
            //nạp file html vào
            this.html = html;

            //nạp template
            webBrowser1.Navigate(Application.StartupPath + "\\report\\print_template.html");
            this.Show();
            
        }
        void init_report()
        {
            DateTime now = DateTime.Now;
            string time = string.Format("Thời điểm in: {0} ngày {1}", now.ToString("HH:mm:ss"), now.ToString("dd/MM/yyyy"));
            webBrowser1.Document.InvokeScript("ShowTable", new object[] { html, tieude, time });

            string strKey = "Software\\Microsoft\\Internet Explorer\\PageSetup";
            bool bolWritable = true;
            string strName = "header";
            object oValue = "-> Cửa Hàng Dkid - mua hàng k phải nghí <-";
            RegistryKey oKey = Registry.CurrentUser.OpenSubKey(strKey, bolWritable);
            Console.Write(strKey);
            oKey.SetValue(strName, oValue);
            oKey.Close();

            this.Hide();
        }

        //sự kiện này đc chạy khi webBorwser 1 tải xong trang html_template
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                init_report();
            }
            catch { }
        }

        private void finGlobal_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        //hàm public này để js trong WebBrowser1 gọi được
        //khi gọi phải gọi qua lệnh window.external.Print_Callback()
        //nó đã đc gọi tại dòng 66 trong code js của file print_template.html
        public void Print_Callback()
        {
            //show hộp thoại để xem trước khi print
            //hộp thoại này cho phép user chọn máy in, căn lề, khổ giấy...
            //nó sẽ print thật ra giấy, hoặc pdf,... tuỳ phần cứng!
            webBrowser1.ShowPrintPreviewDialog();
            //webBrowser1.WebBrowserShortcutsEnabled = false;

        }
    }
}
