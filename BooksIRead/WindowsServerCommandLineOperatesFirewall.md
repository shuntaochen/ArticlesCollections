Windows Server2008增加了一个名叫netsh的命令行工具，通过它可以用批处理方式添加防火墙出入栈规则：

入栈规则：

set PORT=3389
set RULE_NAME="_远程连接端口：%PORT% 入栈规则"
netsh advfirewall firewall show rule name=%RULE_NAME% >nul
if not ERRORLEVEL 1 (
    rem 对不起，规则 %RULENAME% 已经存在
) else (
    echo 规则 %RULENAME% 创建中...
    netsh advfirewall firewall add rule name=%RULE_NAME% dir=in action=allow protocol=TCP localport=%PORT%
) 

出栈规则：
set PORT=3389
set RULE_NAME="_远程连接端口：%PORT% 出栈规则"
netsh advfirewall firewall show rule name=%RULE_NAME% >nul
if not ERRORLEVEL 1 (
    rem 对不起，规则 %RULENAME% 已经存在
) else (
    echo 规则 %RULENAME% 创建中...
    netsh advfirewall firewall add rule name=%RULE_NAME% dir=outaction=allow protocol=TCP localport=%PORT%
) 
