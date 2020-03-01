# Windows Terminal 配置文件

复制以下文件：

| 文件夹 | 放置位置 |
| ------ | ----------- |
| WindowsPowerShell | C:\Users\USERNAME\Documents |
| profiles.json | C:\Users\USERNAME\AppData\Local\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState |

最简单的话只要复制那这个文件就行了

需要 [Sarasa Mono 字体](https://github.com/be5invis/Sarasa-Gothic/releases)

## 注册表 (可选)

注册表是可选的，按需导入。导入前**务必**替换*Kenvix*为你的用户名

## 计划任务 (可选)

`Terminal Admin Executor.xml` 是免 UAC 弹框提权所需任务，若需要右键打开 Terminal 以及 Win+X 一键打开，则需要导入这个任务


## 获得文件权限 (可选)

GrantNTFSPermission.exe 提供了一键获得文件所有权的功能

直接丢到 "发送到" (C:\Users\USERNAME\AppData\Roaming\Microsoft\Windows\SendTo) 即可