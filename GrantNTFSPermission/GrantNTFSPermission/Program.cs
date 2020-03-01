using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrantNTFSPermission
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                if (args.Length < 1)
                    throw new ArgumentException("No file specified");

                var path = args[0];

                //创建启动对象
                ProcessStartInfo startInfo = new ProcessStartInfo();

                //设置运行文件
                startInfo.FileName = "cmd.exe";

                //设置启动参数
                if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                {
                    startInfo.Arguments = $"/k takeown /f \"{path}\" /r /d y && icacls \"{path}\" /grant {Environment.UserName}:F /t && exit";
                }
                else
                {
                    startInfo.Arguments = $"/k takeown /f \"{path}\" && icacls \"{path}\" /grant {Environment.UserName}:F && exit";
                }

                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";

                //如果不是管理员，则启动UAC
                Process.Start(startInfo);
            }
            catch (Win32Exception)
            {

            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message} ({e.GetType().FullName})");
            }
        }
    }
}
