find ./ -type f -name \*.nupkg -delete
dotnet restore
dotnet pack -c Release


if ${usenuget}
then
    cd ${WORKSPACE}
    find ./ -type f -name \*1.0.0.nupkg| while read line; do 
	echo $line;
    right=${line%%.1.0.0.nupkg}
    dotnet nuget delete --source http://192.168.1.7:17071/ -k 3cdb9803-86f9-4750-9615-338f14f0c814 --non-interactive ${right##*/} 1.0.0
	dotnet nuget push --source http://192.168.1.7:17071/ -k 3cdb9803-86f9-4750-9615-338f14f0c814 $line
	done
fi
	   
