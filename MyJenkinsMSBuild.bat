#build command
/t:Rebuild /p:Configuration=Release /m /p:DeployOnBuild=True;PublishProfile=ep-bi-service
#to overwrite certain files
copy /y .\EP.Framework.Application\bin\Release\EP.Framework.Application.xml D:\WebPublish\ep-bi-service\bin
