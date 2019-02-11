#put this to some location, by default, echo outputs a new line, if want to append to current line, add -n,some linux versions need no white space
echo "service1 service2 ..." >> a.txt
echo -n " service99" >> a.txt
docker start `cat a.txt`
