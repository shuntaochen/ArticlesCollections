1. Adding alias for commands in cmder
```
1. open cmder directory
2. copy command: vi config/user_aliases.cmd (_in windows)
3. or copy alternative command: vi \vendor\conemu-maximus5\ConEmu.xml
4. add aliases:
alias ss="ssh root@192.168.1.7"
```
2. Cmder console Chinese ***messy code***, this does work:
```
首先，打开cmder，按下快捷键 Win + Alt + P，在搜索框中输入 chcp 后回车，可看到cmder的配置输入框（等同于 Settings-->Startup-->Environment）。

然后，在配置框中，输入 chcp 65001 ，保存设置。

最后，重启cmder，使配置文件生效即可。
```
