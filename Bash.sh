#!/bin/bash
echo "yes"
#no space allowed between variable name and =, "true" "false" is defined this way
usenuget="true"
#use brace to wrap defined variable
if ${usenuget}
then
	echo "publish"
fi
