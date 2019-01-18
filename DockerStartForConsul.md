Server
```
# docker run -d -p 1234:8500 -h node1 --name node1  consul agent -server -bootstrap-expect=1  -node=node1 -client 0.0.0.0 -ui -dc=dc1
# JOIN_IP="$(docker inspect -f '{{.NetworkSettings.IPAddress}}' node1)"
```
Client
```
# consul agent -data-dir=/tmp/agent -node=clinet1 -bind=10.30.0.52 -ui -dc=dc1  ##不使用docker运行的clinet端
# consul join $JOIN_IP
# docker run -d -p 8600:8600 -p 8500:8500 -p 8600:53/udp --name client2 -h client2 consul -ui -node=client2 -join $JOIN_IP  -dc=dc1 ##使用docker运行的client端
```
