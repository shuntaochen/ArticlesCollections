#put this to some location
echo "service1 service2 ..." >> a.txt
docker start `cat a.txt`
