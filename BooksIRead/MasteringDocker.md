1. Move docker storage on Mac
```
Mac下Docker的数据文件目录在~/Library/Containers/com.docker.docker/Data，你可以把整个目录搬到另外一块硬盘上：

mv ~/Library/Containers/com.docker.docker/Data /mnt/docker
然后建立一个软链接链接回来就可以了：

ln -s /mnt/docker/Data ~/Library/Containers/com.docker.docker/Data
```
