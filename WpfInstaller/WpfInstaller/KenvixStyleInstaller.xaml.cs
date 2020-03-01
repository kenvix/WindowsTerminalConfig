using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using SevenZip;

namespace WpfInstaller
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private int lastProgressPercentage = 0;

        /**
         * 文件下载
         **/
        public string FileDownloader(string url, AsyncCompletedEventHandler eventHandler)
        {
            string tempFile = System.IO.Path.GetTempFileName();

            fileurlbox.Text = url;

            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(new Uri(url), tempFile);
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
                client.DownloadFileCompleted += eventHandler;

            }

            return tempFile;
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.downloadInfo.Text = string.Format("已下载{0}KB / 共{1}KB", e.BytesReceived / 1000, e.TotalBytesToReceive / 1000);

            //防止进度条倒退
            if (lastProgressPercentage <= e.ProgressPercentage)
            {
                this.DownloaderPbar.Value = e.ProgressPercentage;
            }

        }

        void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("文件下载被取消");
            }

            this.DownloaderPbar.Value = 0;
            DownloadContentText.Text = "";

            this.downloadInfo.Text = "文件下载成功";
        }

        /**
         * 解压
         * */

        public void Un7zip(string zipFile, string saveTo)
        {
            using (var tmp = new SevenZipExtractor(zipFile))
            {
                for (var i = 0; i < tmp.ArchiveFileData.Count; i++)
                {
                    tmp.ExtractFiles(saveTo, tmp.ArchiveFileData[i].Index);
                }
            }
        }

        /**
         * main
         * */
        public void InstallFonts()
        {
            downloadFonts();

            //下载
            void downloadFonts()
            {
                DownloadContentText.Text = "缺失的字体";
                string filepath = FileDownloader(
                    "https://www.baidu.com/img/bd_logo1.png",
                    unzipFonts
                    );
            }

            //解压缩
            void unzipFonts(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
            {
                DownloadContentText.Text = "解压字体文件";

            }

            void moveFontsToPath()
            {

            }
        }

        public MainWindow()
        {
            //检查管理员权限
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                MessageBox.Show("请使用管理员权限运行安装程序");
                System.Environment.Exit(0);
            }

            //加载窗体
            InitializeComponent();
            usernamebox.Text = Environment.UserName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //下载字体
            InstallFonts();
        }
    }
}
