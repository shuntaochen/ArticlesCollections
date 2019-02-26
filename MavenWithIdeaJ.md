Using Sping boot and IdeaJ
---
1. IdeaJ create Spring-boot project
```
spring-> web-> create
```
2. Maven using domestic mirrors
```
#method1
folder "apache-maven-{version}" -> conf> settings.xml-> mirrors-> add aliyun mirror
#method2
tool bar->settings->maven->repository->override user settings-> save to ~/.m2/settings.xml
```
3. Run Spring-boot application
```
#preparation
change demoapplication.java with some spring imports and annotations
#method1
mvn spring-boot:run
#method2
idea tool bar-> run-> edit config-> select module, main class, and other options-> run -> visit localhost:8080
```
4. Using Quick fix in IdeaJ
```
Press "Alt+Enter", help intelligence
Press "Alt+Insert", generates getter and setter, constructor, etc
```
