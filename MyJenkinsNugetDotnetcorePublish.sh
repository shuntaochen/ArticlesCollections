

dotnet pack -c Release

if ${usenuget}
then
	for fragment in Commons.Core Commons.Config Commons.Migrator Commons.Permission Commons.Rest RemoteEventBus RemoteEventBus.Redis; do
	cd ${WORKSPACE}/EP.${fragment}/obj/Release
	echo $pwd
        dotnet nuget delete --source http://192.168.1.7:17071/ -k 3cdb9803-86f9-4750-9615-338f14f0c814 --non-interactive EP.${fragment} 1.0.0
	dotnet nuget push -Source http://192.168.1.7:17071/ -ApiKey 3cdb9803-86f9-4750-9615-338f14f0c814 EP.${fragment}.1.0.0.nupkg
done
fi
	   
