
dotnet restore
dotnet pack -c Release





if ${usenuget}
then
	for fragment in EP.Commons.Core EP.Commons.Config EP.Commons.Migrator EP.Commons.Permission EP.Commons.Rest EP.RemoteEventBus EP.RemoteEventBus.Redis NanoFabric.Core NanoFabric.RegistryHost.ConsulRegistry NanoFabric.Router; do
	cd ${WORKSPACE}/EP.${fragment}/bin/Release
	echo $pwd
    dotnet nuget delete --source http://192.168.1.7:17071/ -k 3cdb9803-86f9-4750-9615-338f14f0c814 --non-interactive ${fragment} 1.0.0
    done
    cd ${WORKSPACE}
    find ./ -type f -name \*.nupkg| while read line; do 
	echo $line;
	dotnet nuget push --source http://192.168.1.7:17071/ -k 3cdb9803-86f9-4750-9615-338f14f0c814 $line
	done
fi
	   
