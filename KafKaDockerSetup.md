Structure map of Zookeeper and kafka ![Map](https://upload-images.jianshu.io/upload_images/8818451-7fa3bebabccb0c3e.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/554/format/webp)
1. Zookeeper, configuration files locates in container under  /conf/zoo.cfg, /data , /datalog
``` 
docker run --name some-zookeeper \
--restart always \
-p 18030:2181 \
-d zookeeper
```
2. Kafka
```
docker run --name kafka \
-p 18029:9092 \
-e KAFKA_ADVERTISED_HOST_NAME=kafka01 \
-e KAFKA_CREATE_TOPICS="test:1:1" \
-e KAFKA_ZOOKEEPER_CONNECT=192.168.1.7:18030 \
-d  wurstmeister/kafka 
```
3. Kafka manager
```
docker run -itd \
--restart=always \
--name=kafka-manager \
-p 18028:9000 \
-e ZK_HOSTS="192.168.1.7:18030" \
sheepkiller/kafka-manager
```
4. Visit 192.168.1.7:18028 for Kafka cluster management
