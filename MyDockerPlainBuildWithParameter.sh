cd src/EP.OcelotGatewey.WebApi
cp -f Dockerfile ${WORKSPACE}/
dispose(){
cd ${WORKSPACE}
docker stop ep-ocelot
docker rm ep-ocelot
docker rmi epocelotgateway
}
launch(){
cd ${WORKSPACE}
docker build -t epocelotgateway .
docker run -d --name ep-ocelot -p 18030:18030 epocelotgateway
}
if test ${ISINIT}=="TRUE"
then
launch
else
dispose
launch
fi




