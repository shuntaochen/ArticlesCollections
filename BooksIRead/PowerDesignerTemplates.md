Customize power designer templates
for columns:
```
.if (%isValidAttribute%)

///<summary>
///[%Name%]
///[%comment%\n]\
///</summary>
[%customAttributes%\n]\
.if (%Multiple% == false) and (%isIndexer% == false)
[%visibility% ][%flags% ]%dataType% %Code%[ = %InitialValue%]{get;set;}
.else
[%visibility% ][%flags% ]%dataType%[%arraySize%] %Code%[ = %InitialValue%]{get;set;}
.endif
.endif
```
for namespace:

```
.// only toplevel classes are generated
.if (%ContainerClassifier% == null)
.// header and usings
[\
%usings%\n
]\
.// class/interface definition (global namespace)
.ifnot (%Package.namespace%)
namespace Tiandi.Web.Authority.Model
{
%definition%
}
.else
[\
%Package.comment%
]\
[\
%Package.customAttributes%
]\
namespace %Package.namespace%
{
%definition%
}
.endif
.endif
```
