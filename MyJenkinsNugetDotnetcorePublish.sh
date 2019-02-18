find ./ -type f -name \*.nupkg -delete
dotnet restore
dotnet pack -c Release

dispose(){
    cd ${WORKSPACE}
    find ./ -type f -name \*1.0.0.nupkg| while read line; do 
	echo $line;
    right=${line%%.1.0.0.nupkg}
    dotnet nuget delete --source http://192.168.1.7:17071/ -k 3cdb9803-86f9-4750-9615-338f14f0c814 --non-interactive ${right##*/} 1.0.0
	done
}
push(){
    cd ${WORKSPACE}
    find ./ -type f -name \*1.0.0.nupkg| while read line; do 
	echo $line;
    right=${line%%.1.0.0.nupkg}
	dotnet nuget push --source http://192.168.1.7:17071/ -k 3cdb9803-86f9-4750-9615-338f14f0c814 $line
	done
    }

if test ${emptyinventory} = True
then
dispose
fi
if test ${pushtoinventoty} = True
then
push
fi
