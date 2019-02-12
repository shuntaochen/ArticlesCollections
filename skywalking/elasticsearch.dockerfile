FROM elasticsearch:5.6.4

EXPOSE 9200 9300

COPY elasticsearch.yml /usr/share/elasticsearch/config/