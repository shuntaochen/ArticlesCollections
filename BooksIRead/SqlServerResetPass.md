> This is a method found on the web, haven't tried yet
一、以管理员权限运行命令提示符 CMD

C:\>net stop mssqlserver
您想继续此操作吗? (Y/N) [N]: y

C:\>net start mssqlserver /m

C:\>sqlcmd -e -s .

1> ALTER LOGIN sa WITH PASSWORD = '新密码' UNLOCK
2> go
ALTER LOGIN sa WITH PASSWORD = '新密码' UNLOCK

1> exit

二、开始进行，执行 services.msc，找到并重启 SQL Server (MSSQLSERVER) 服务
