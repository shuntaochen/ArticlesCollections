### To check whether crontabs is installed
```
service crond status
```
### If not, use commands
```
# Installation
yum install crontabs
# Enable on system reboot
chkconfig --level 35 crond on
#crontab options: -e edit timer setting; -l list user timer settings -r remove one; -uusername specify timer username
#Format: "miniute hour month day week command commandargs", spearators: - range, * all, / every
```
