var ret={}
for(var i=0;i<3;i++){

var key=keys[i]

ret[key]={}
if(i==0){
//only keep the first reference
console.log(ret);
}
ret=ret[key]
if(i==2){ ret[key]=3;}
}
