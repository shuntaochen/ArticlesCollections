var keys=['a','b','c']
var ret={}
var x={}
for(var i=0;i<3;i++){

var key=keys[i]

ret[key]={}
if(i==0){
x=ret;
console.log(ret);
}
ret=ret[key]
if(i==2){ ret[key]=3;}
}
console.log(x)
