# Windows Terminal 配置文件

| 文件夹 | 放置位置 |
| ------ | ----------- |
| WindowsPowerShell | C:\Users\USERNAME\Documents |
| profiles.json | C:\Users\USERNAME\AppData\Local\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState |

需要 [Sarasa Mono 字体](https://github.com/be5invis/Sarasa-Gothic/releases)

## 注册表

注册表是可选的，按需导入。

## 计划任务

`Terminal Admin Executor.xml` 是免 UAC 弹框提权所需任务，若需要右键打开 Terminal 以及 Win+X 一键打开，则需要导入这个任务