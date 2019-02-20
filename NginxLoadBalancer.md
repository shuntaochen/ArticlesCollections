### Setting up nginx reverse proxy for loadbalancing

1. In /etc/nginx nginx.conf, add loadbalance settings
```
# In http {} section, add settings
upstream thegateways {
server 192.168.1.7:18030;
server 192.168.1.7:18031;
}
server {
  listen 18055;
  server_name thegateways;
  location / {
          proxy_pass http://thegateways;
          index index.html index.htm;
  }
}

```
2. Reload settings
```
#view nginx processes, usually 5
ps -ef | grep nginx
#Reload process config but not kill the process, use -HUP, means hang up.
Kill -HUP masterprocessid
#restart nginx
nginx -c /etc/nginx/nginx.conf
#reload setting
nginx -s reload
```
3. Visit 192.168.1.7:18055, and the upstream is loadbalanced between servers
As to other detailed strategies for nginx settings, refer to other materials, eg the official document.
