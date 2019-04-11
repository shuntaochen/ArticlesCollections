List转换为Array可以这样处理：

ArrayList<String> list=new ArrayList<String>();

String[] strings = new String[list.size()];

list.toArray(strings);

反过来，如果要将数组转成List怎么办呢？如下：

String[] s = {"a","b","c"};
List list = java.util.Arrays.asList(s);
